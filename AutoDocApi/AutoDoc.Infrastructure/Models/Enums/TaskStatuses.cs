using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Models.Enums
{
    /// <summary>
    /// Статусы задач
    /// </summary>
    public enum TaskStatuses
    {
        /// <summary>
        /// Добавлена
        /// </summary>
        [Description("Файл добавлен")]
        Added = 1,

        /// <summary>
        /// Обновлена
        /// </summary>
        [Description("Файл обновлен")]
        Updated = 2,

        /// <summary>
        /// Удалена
        /// </summary>
        [Description("Файл удален")]
        Removed = 3,
    }
}
