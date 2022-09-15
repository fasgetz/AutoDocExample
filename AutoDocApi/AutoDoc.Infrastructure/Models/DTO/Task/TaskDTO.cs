using AutoDoc.Infrastructure.Models.DTO.Files;
using AutoDoc.Infrastructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Models.DTO.Task
{
    public class TaskDTO
    {
        /// <summary>
        /// Номер в базе данных
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата создания файла
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Статус файла
        /// </summary>
        public TaskStatuses FileTask { get; set; }

        /// <summary>
        /// Файлы
        /// </summary>
        public ICollection<FileDTO> Files { get; set; }
    }
}
