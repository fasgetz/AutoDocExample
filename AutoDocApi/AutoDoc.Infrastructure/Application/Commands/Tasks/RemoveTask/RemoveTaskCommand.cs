using AutoDoc.Infrastructure.Models.DTO.Task;
using AutoDoc.Infrastructure.Models.Responses.Tasks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Application.Commands.Tasks.RemoveTask
{
    /// <summary>
    /// Команда на удаление таски
    /// </summary>
    public class RemoveTaskCommand : IRequest<RemoveTaskResponse>
    {
        /// <summary>
        /// Номер таски
        /// </summary>
        public int Id { get; set; }
    }
}
