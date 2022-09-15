using AutoDoc.DataBase.ContextDb;
using AutoDoc.Domain.Models;
using AutoDoc.Infrastructure.Models.DTO.Task;
using AutoDoc.Infrastructure.Models.Enums;
using AutoDoc.Infrastructure.Models.Responses.Tasks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Application.Commands.Tasks.AddTask
{
    /// <summary>
    /// Обработчик команды на добавление задачи
    /// </summary>
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, AddTaskResponse>
    {
        private readonly AutoDocContext db;

        public AddTaskCommandHandler(AutoDocContext db)
        {
            this.db = db;
        }

        public async Task<AddTaskResponse> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            await using var transaction = await db.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                // Первым делом, добавляем в базу таску
                // И файлы к ней
                TaskAutoDoc task = new TaskAutoDoc()
                {
                    Name = request.Name,
                    CreatedDate = DateTime.Now,
                    TaskStatusId = (byte)TaskStatuses.Added,
                    Files = request.Files?.Select(e => new FileAutoDoc()
                    {
                        Name = e.FileName,
                        FileStatusId = (byte)FileStatuses.Added,
                    }).ToList()
                };

                await db.Tasks.AddAsync(task);
                await db.SaveChangesAsync(cancellationToken);

                if (request.Files != null)
                {
                    // После того, как добавили таску (+ файлы)
                    // Необходимо сохранить их себе на диск
                    foreach (var file in request.Files)
                    {
                        string filePath = $"/files/{task.Id}";

                        Directory.CreateDirectory(filePath);

                        file.CopyTo(new FileStream($"{filePath}/{file.FileName}", FileMode.Create));
                    }
                }

                // Завершаем транзакцию в бд
                await transaction.CommitAsync(cancellationToken);

                return new AddTaskResponse()
                {
                    IdTask = task.Id,
                    DateCreated = task.CreatedDate,
                    Name = task.Name,
                    FileNames = task.Files?.Select(e => e.Name).ToList()
                };
            }
            catch (Exception ex)
            {
                // Откатываем транзакцию
                await transaction.RollbackAsync();

                throw new Exception("Во время добавления задачи возникли ошибки");
            }
        }
    }
}
