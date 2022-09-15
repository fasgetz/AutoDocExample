using AutoDoc.Infrastructure.Models.DTO.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Application.Queries.Tasks
{
    /// <summary>
    /// Запросы с тасками
    /// </summary>
    public interface ITaskQueries
    {
        /// <summary>
        /// Получение задачи по номеру
        /// </summary>
        /// <param name="id">Номер задачи в бд</param>
        /// <returns></returns>
        Task<TaskDTO> GetTask(int id);

        /// <summary>
        /// Список задач с пагинацией
        /// </summary>
        /// <param name="take">Сколько взять</param>
        /// <param name="skip">Сколько пропустить</param>
        /// <returns></returns>
        Task<IEnumerable<TaskDTO>> GetTasks(int take, int skip);
    }
}
