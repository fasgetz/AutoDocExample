using AutoDoc.DataBase.ContextDb;
using AutoDoc.Infrastructure.Application.Commands.Tasks.AddTask;
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

namespace AutoDoc.Infrastructure.Application.Commands.Tasks.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, UpdateTaskResponse>
    {
        private readonly AutoDocContext db;

        public UpdateTaskCommandHandler(AutoDocContext db)
        {
            this.db = db;
        }

        public async Task<UpdateTaskResponse> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            // Первым делом ищем нашу таску по айди
            var task = await db.Tasks.FirstOrDefaultAsync(e => e.Id == request.Id);

            if (task == null)
                throw new Exception("Задача не найдена");

            if (task.TaskStatusId == (byte)TaskStatuses.Removed)
                throw new Exception("Задача удалена");

            // Если задача найдена, то обновить ей данные
            await using var transaction = await db.Database.BeginTransactionAsync(cancellationToken);

            task.Name = request.Name;
            task.TaskStatusId = (byte)TaskStatuses.Updated;

            await db.SaveChangesAsync(cancellationToken);

            // Завершаем транзакцию в бд
            await transaction.CommitAsync(cancellationToken);

            return new UpdateTaskResponse()
            {
                IdTask = task.Id,
                DateCreated = task.CreatedDate,
                Name = task.Name
            };
        }
    }
}
