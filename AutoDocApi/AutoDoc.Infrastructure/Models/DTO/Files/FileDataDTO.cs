using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Models.DTO.Files
{
    /// <summary>
    /// Содержимое файла
    /// </summary>
    public class FileDataDTO
    {
        /// <summary>
        /// Название файла
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Тип файла
        /// </summary>
        public string ContentType { get; set; }

        public byte[] Bytes { get; set; }
    }
}
