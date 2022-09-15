using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Models.Responses.Files
{
    /// <summary>
    /// Ответ на запрос добавления файла задаче
    /// </summary>
    public class AddFileResponse
    {
        /// <summary>
        /// Номер файла в бд
        /// </summary>
        public int IdFile { get; set; }
        
        /// <summary>
        /// Название файла
        /// </summary>
        public string Name { get; set; }
    }
}
