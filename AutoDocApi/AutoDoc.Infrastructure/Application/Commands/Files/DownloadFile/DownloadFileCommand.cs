using AutoDoc.Infrastructure.Models.DTO.Files;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Application.Commands.Files.DownloadFile
{
    public class DownloadFileCommand : IRequest<FileDataDTO>
    {
        /// <summary>
        /// Номер файла
        /// </summary>
        public int IdFile { get; set; }
    }
}
