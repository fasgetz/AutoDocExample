using AutoDoc.Infrastructure.Models.DTO.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Models.Responses.Tasks
{
    public class UpdateTaskResponse
    {
        /// <summary>
        /// Номер задачи
        /// </summary>
        public long IdTask { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата создания задачи
        /// </summary>
        public DateTime DateCreated { get; set; }
    }
}
