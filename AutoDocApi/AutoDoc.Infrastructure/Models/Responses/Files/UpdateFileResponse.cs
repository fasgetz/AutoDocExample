using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Models.Responses.Files
{
    /// <summary>
    /// Ответ на запрос обновления файла
    /// </summary>
    public class UpdateFileResponse
    {
        /// <summary>
        /// Номер файла
        /// </summary>
        public int IdFile { get; set; }

        /// <summary>
        /// Новое название файла
        /// </summary>
        public string Name { get; set; }
    }
}
