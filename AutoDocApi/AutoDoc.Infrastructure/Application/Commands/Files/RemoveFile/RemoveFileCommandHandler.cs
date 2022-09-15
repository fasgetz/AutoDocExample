using AutoDoc.DataBase.ContextDb;
using AutoDoc.Infrastructure.Models.Enums;
using AutoDoc.Infrastructure.Models.Responses.Files;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Application.Commands.Files.RemoveFile
{
    public class RemoveFileCommandHandler : IRequestHandler<RemoveFileCommand, RemoveFileResponse>
    {
        private readonly AutoDocContext db;

        public RemoveFileCommandHandler(AutoDocContext db)
        {
            this.db = db;
        }

        public async Task<RemoveFileResponse> Handle(RemoveFileCommand request, CancellationToken cancellationToken)
        {
            // Первым делом ищем нашу таску по айди
            var file = await db.Files.FirstOrDefaultAsync(e => e.Id == request.IdFile);

            if (file == null)
                throw new Exception("Файл не найден");

            if (file.FileStatusId == (byte)FileStatuses.Removed)
                throw new Exception("Файл уже удален");

            // Если задача найдена, то обновить ей данные
            await using var transaction = await db.Database.BeginTransactionAsync(cancellationToken);

            // Ставим статус удалено у задачи и ее файлов
            file.FileStatusId = (byte)FileStatuses.Removed;

            await db.SaveChangesAsync(cancellationToken);

            // Завершаем транзакцию в бд
            await transaction.CommitAsync(cancellationToken);

            return new RemoveFileResponse()
            {
                FileId = file.Id,
                TaskId = file.TaskId,
                FileName = file.Name
            };
        }
    }
}
