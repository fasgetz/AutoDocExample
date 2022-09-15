using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Models.Enums
{
    /// <summary>
    /// Статусы файлов
    /// </summary>
    public enum FileStatuses
    {
        /// <summary>
        /// Добавлен
        /// </summary>
        Added = 4,

        /// <summary>
        /// Обновлен
        /// </summary>
        Updated = 5,

        /// <summary>
        /// Удален
        /// </summary>
        Removed = 6,
    }
}
