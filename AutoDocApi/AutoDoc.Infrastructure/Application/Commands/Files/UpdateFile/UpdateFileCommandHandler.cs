using AutoDoc.DataBase.ContextDb;
using AutoDoc.Infrastructure.Application.Commands.Files.AddFile;
using AutoDoc.Infrastructure.Models.Enums;
using AutoDoc.Infrastructure.Models.Responses.Files;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Application.Commands.Files.UpdateFile
{
    public class UpdateFileCommandHandler : IRequestHandler<UpdateFileCommand, UpdateFileResponse>
    {
        private readonly AutoDocContext db;

        public UpdateFileCommandHandler(AutoDocContext db)
        {
            this.db = db;
        }

        public async Task<UpdateFileResponse> Handle(UpdateFileCommand request, CancellationToken cancellationToken)
        {
            await using var transaction = await db.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                // Первым делом ищем файл в бд
                var file = await db.Files.FirstOrDefaultAsync(e => e.Id == request.IdFile);

                if (file == null)
                    throw new Exception("Файла нет в базе данных");

                if (file.FileStatusId == (byte)FileStatuses.Removed)
                    throw new Exception("Файл удален - обновить невозможно!");

                // После того, как добавили в БД, необходимо удалить старый и добавить новый файл
                string filePath = $"/files/{file.TaskId}";

                // Необходимо удалить старый файл
                File.Delete($"{filePath}/{file.Name}");

                // Теперь добавляем новый

                file.FileStatusId = (byte)FileStatuses.Updated;
                file.Name = $"{Guid.NewGuid()}-" + request.File.FileName;

                await db.SaveChangesAsync(cancellationToken);

                request.File.CopyTo(new FileStream($"{filePath}/{file.Name}", FileMode.Create));

                // Завершаем транзакцию в бд
                await transaction.CommitAsync(cancellationToken);

                return new UpdateFileResponse()
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
