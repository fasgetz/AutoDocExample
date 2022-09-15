using AutoDoc.Infrastructure.Models.DTO.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Application.Queries.Files
{
    public interface IFileQueries
    {
        /// <summary>
        /// Получить файл по номеру
        /// </summary>
        /// <param name="id">Номер файла</param>
        /// <returns></returns>
        Task<FileDTO> GetFile(int id);

        /// <summary>
        /// Получить список файлов
        /// </summary>
        /// <param name="take">Пропустить</param>
        /// <param name="skip">Взять</param>
        /// <returns></returns>
        Task<IEnumerable<FileDTO>> GetFiles(int take, int skip);
    }
}
