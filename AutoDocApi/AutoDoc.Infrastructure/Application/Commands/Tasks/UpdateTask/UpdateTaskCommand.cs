using AutoDoc.Infrastructure.Models.DTO.Task;
using AutoDoc.Infrastructure.Models.Responses.Tasks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Application.Commands.Tasks.UpdateTask
{
    /// <summary>
    /// Команда на обновление таск
    /// </summary>
    public class UpdateTaskCommand : IRequest<UpdateTaskResponse>
    {
        /// <summary>
        /// Номер задачи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название таски
        /// </summary>
        public string? Name { get; set; }
    }
}
