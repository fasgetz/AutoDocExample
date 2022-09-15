using AutoDoc.DataBase.ContextDb;
using AutoDoc.Domain.Models;
using AutoDoc.Infrastructure.Models.Enums;
using AutoDoc.Infrastructure.Models.Responses.Files;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Application.Commands.Files.AddFile
{
    public class AddFileCommandHandler : IRequestHandler<AddFileCommand, AddFileResponse>
    {
        private readonly AutoDocContext db;

        public AddFileCommandHandler(AutoDocContext db)
        {
            this.db = db;
        }

        public async Task<AddFileResponse> Handle(AddFileCommand request, CancellationToken cancellationToken)
        {
            await using var transaction = await db.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                // Первым делом ищем таску в бд
                var task = await db.Tasks.FirstOrDefaultAsync(e => e.Id == request.IdTask);

                if (task == null)
                    throw new Exception("Задачи нет в базе данных");

                if (task.TaskStatusId == (byte)TaskStatuses.Removed)
                    throw new Exception("Задача удалена - файл добавить невозможно!");

                var file = new FileAutoDoc()
                {
                    TaskId = task.Id,
                    Name = $"{Guid.NewGuid()}-" + request.File.FileName,
                    FileStatusId = (byte)FileStatuses.Added
                };

                await db.Files.AddAsync(file);
                await db.SaveChangesAsync(cancellationToken);

                // После того, как добавили в БД, необходимо добавить файл
                string filePath = $"/files/{task.Id}";

                Directory.CreateDirectory(filePath);

                request.File.CopyTo(new FileStream($"{filePath}/{file.Name}", FileMode.Create));

                // Завершаем транзакцию в бд
                await transaction.CommitAsync(cancellationToken);

                return new AddFileResponse()
                {
                    IdFile = file.Id,
                    Name = file.Name
                };
            }
            catch (Exception ex)
            {
                // Откатываем транзакцию
                await transaction.RollbackAsync();

                throw new Exception(ex.Message);
            }
        }
    }
}
