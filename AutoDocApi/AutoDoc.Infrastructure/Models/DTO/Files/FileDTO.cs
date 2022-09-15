using AutoDoc.Infrastructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Models.DTO.Files
{
    /// <summary>
    /// DTO файла
    /// </summary>
    public class FileDTO
    {
        /// <summary>
        /// Номер файла
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название файла
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Статус файла
        /// </summary>
        public FileStatuses FileStatus { get; set; }

        /// <summary>
        /// Номер таски
        /// </summary>
        public int TaskId { get; set; }
    }
}
