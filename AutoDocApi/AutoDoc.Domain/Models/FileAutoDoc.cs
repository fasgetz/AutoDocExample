using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Domain.Models
{
    /// <summary>
    /// Файл
    /// </summary>
    public class FileAutoDoc
    {
        /// <summary>
        /// Номер в бд
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название файла
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Задача
        /// </summary>
        public int TaskId { get; set; }
        public TaskAutoDoc Task { get; set; }

        /// <summary>
        /// Статус файла
        /// </summary>
        public byte FileStatusId { get; set; }
        public AutoDocStatus FileStatus { get; set; }
    }
}
