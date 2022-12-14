using AutoDoc.Infrastructure.Models.Responses.Files;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Application.Commands.Files.AddFile
{
    public class AddFileCommand : IRequest<AddFileResponse>
    {
        /// <summary>
        /// Номер задачи
        /// </summary>
        public int IdTask { get; set; }

        /// <summary>
        /// Файл
        /// </summary>
        public IFormFile File { get; set; }
    }
}
