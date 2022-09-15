using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Models.Requests.Tasks
{
    /// <summary>
    /// Запрос на удаление таски
    /// </summary>
    public class RemoveTaskRequest
    {
        /// <summary>
        /// Номер таски
        /// </summary>
        public int Id { get; set; }
    }
}
