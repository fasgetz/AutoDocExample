using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Domain.Models
{
    /// <summary>
    /// Сущность задачи
    /// </summary>
    public class TaskAutoDoc
    {
        /// <summary>
        /// Номер задачи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Статус задачи
        /// </summary>
        public byte TaskStatusId { get; set; }
        public AutoDocStatus TaskStatus { get; set; }

        /// <summary>
        /// Файлы задачи
        /// </summary>
        public ICollection<FileAutoDoc> Files { get; set; }
    }
}
