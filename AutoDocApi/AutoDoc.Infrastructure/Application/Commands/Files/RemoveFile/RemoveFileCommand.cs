using AutoDoc.Infrastructure.Models.Responses.Files;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Application.Commands.Files.RemoveFile
{
    /// <summary>
    /// Команда на удаление файла
    /// </summary>
    public class RemoveFileCommand : IRequest<RemoveFileResponse>
    {
        /// <summary>
        /// Номер файла
        /// </summary>
        public int IdFile { get; set; }
    }
}
