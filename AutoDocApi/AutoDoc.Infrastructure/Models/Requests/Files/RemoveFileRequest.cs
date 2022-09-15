using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Models.Requests.Files
{
    /// <summary>
    /// Запрос на удаление файла
    /// </summary>
    public class RemoveFileRequest
    {
        /// <summary>
        /// Номер файла
        /// </summary>
        public int IdFile { get; set; }
    }
}
