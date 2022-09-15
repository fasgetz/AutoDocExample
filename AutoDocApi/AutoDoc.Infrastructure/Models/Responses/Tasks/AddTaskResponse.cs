using AutoDoc.Infrastructure.Models.DTO.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Models.Responses.Tasks
{
    /// <summary>
    /// Ответ на добавление задачи
    /// </summary>
    public class AddTaskResponse
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

        /// <summary>
        /// Названия добавленных файлов
        /// </summary>
        public ICollection<string> FileNames { get; set; }
    }
}
