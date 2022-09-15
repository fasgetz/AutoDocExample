using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Models.Responses.Files
{
    /// <summary>
    /// Ответ на запрос удаленного файла
    /// </summary>
    public class RemoveFileResponse
    {
        public int TaskId { get; set; }
        public int FileId { get; set; }
        public string FileName { get; set; }
    }
}
