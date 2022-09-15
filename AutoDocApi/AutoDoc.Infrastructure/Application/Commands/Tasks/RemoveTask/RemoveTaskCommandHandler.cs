using AutoDoc.DataBase.ContextDb;
using AutoDoc.Infrastructure.Models.DTO.Task;
using AutoDoc.Infrastructure.Models.Enums;
using AutoDoc.Infrastructure.Models.Responses.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Application.Commands.Tasks.RemoveTask
{
    public class RemoveTaskCommandHandler : IRequestHandler<RemoveTaskCommand, RemoveTaskResponse>
    {
        private readonly AutoDocContext db;

        public RemoveTaskCommandHandler(AutoDocContext db)
        {
            this.db = db;
        }

        public async Task<RemoveTaskResponse> Handle(RemoveTaskCommand request, CancellationToken cancellationToken)
        {
            // Первым делом ищем нашу таску по айди
            var task = await db.Tasks.Include(e => e.Files).FirstOrDefaultAsync(e => e.Id == request.Id);

            if (task == null)
                throw new Exception("Задача не найдена");

            if (task.TaskStatusId == (byte)TaskStatuses.Removed)
                throw new Exception("Задача уже удалена");

            // Если задача найдена, то обновить ей данные
            await using var transaction = await db.Database.BeginTransactionAsync(cancellationToken);

            // Ставим статус удалено у задачи и ее файлов
            task.TaskStatusId = (byte)TaskStatuses.Removed;

            task.Files?.ToList().ForEach(x =>
            {
                x.FileStatusId = (byte)FileStatuses.Removed;
            });

            await db.SaveChangesAsync(cancellationToken);

            // Завершаем транзакцию в бд
            await transaction.CommitAsync(cancellationToken);

            return new RemoveTaskResponse()
            {
                IdTask = task.Id,
                DateCreated = task.CreatedDate,
                Name = task.Name,
                Files = task.Files?.Select(e => new Models.DTO.Files.FileDTO()
                {
                    Id = e.Id,
                    Name = e.Name,
                    TaskId = e.TaskId,
                    FileStatus = (FileStatuses)e.FileStatusId
                }).ToList()
            };
        }
    }
}
