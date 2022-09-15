using AutoDoc.DataBase.ContextDb;
using AutoDoc.Infrastructure.Models.DTO.Files;
using AutoDoc.Infrastructure.Models.Enums;
using MediatR;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Application.Commands.Files.DownloadFile
{
    public class DownloadFileCommandHandler : IRequestHandler<DownloadFileCommand, FileDataDTO>
    {
        private readonly AutoDocContext db;

        public DownloadFileCommandHandler(AutoDocContext db)
        {
            this.db = db;
        }

        public async Task<FileDataDTO> Handle(DownloadFileCommand request, CancellationToken cancellationToken)
        {
            var file = await db.Files.FirstOrDefaultAsync(e => e.Id == request.IdFile);

            if (file == null)
                throw new Exception("Файл не найден");

            if (file.FileStatusId == (byte)FileStatuses.Removed)
                throw new Exception("Файл удален");

            // Иначе, если файл найден и все ок, то вернуть
            string filePath = $"/files/{file.TaskId}/{file.Name}";
            string contentType = "";

            new FileExtensionContentTypeProvider().TryGetContentType(filePath, out contentType);

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);

            return new FileDataDTO()
            {
                Bytes = bytes,
                ContentType = contentType,
                FileName = file.Name
            };
        }
    }
}
