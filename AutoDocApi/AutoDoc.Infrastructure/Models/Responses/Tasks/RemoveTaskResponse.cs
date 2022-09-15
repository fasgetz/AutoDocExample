using AutoDoc.Infrastructure.Models.DTO.Files;
using AutoDoc.Infrastructure.Models.DTO.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Models.Responses.Tasks
{
    /// <summary>
    /// Ответ на запрос удаления таски
    /// </summary>
    public class RemoveTaskResponse
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
        /// Удаленные файлы
        /// </summary>
        public ICollection<FileDTO> Files { get; set; }
    }
}
