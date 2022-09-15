using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Domain.Models
{
    /// <summary>
    /// Статусы задач и файлов
    /// </summary>
    public class AutoDocStatus
    {
        /// <summary>
        /// Номер статуса
        /// </summary>
        public byte Id { get; set; }

        /// <summary>
        /// Наименование статуса
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Задачи
        /// </summary>
        public ICollection<TaskAutoDoc> Tasks { get; set; }

        /// <summary>
        /// Задачи
        /// </summary>
        public ICollection<FileAutoDoc> Files { get; set; }
    }
}
