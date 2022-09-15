using AutoDoc.Infrastructure.Models.DTO.Task;
using AutoDoc.Infrastructure.Models.Responses.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Application.Commands.Tasks.AddTask
{
    public class AddTaskCommand : IRequest<AddTaskResponse>
    {
        /// <summary>
        /// Название таски
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Файлы
        /// </summary>
        public ICollection<IFormFile>? Files { get; set; }
    }
}
