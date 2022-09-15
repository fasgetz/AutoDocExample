using AutoDoc.Infrastructure.Application.Commands.Tasks.AddTask;
using AutoDoc.Infrastructure.Application.Commands.Tasks.RemoveTask;
using AutoDoc.Infrastructure.Application.Commands.Tasks.UpdateTask;
using AutoDoc.Infrastructure.Application.Queries.Tasks;
using AutoDoc.Infrastructure.Models.Requests.Tasks;
using AutoDoc.Infrastructure.Models.Responses.Tasks;
using AutoDoc.Utils.AspNet.Controllers;
using AutoDoc.Utils.AspNet.DataTypes;
using AutoDoc.Utils.TraceHolder.TraceHolder.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoDoc.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(ContentType.Json)]
    public class TaskController : BaseApiController
    {
        private readonly ITaskQueries taskQueries;
        private readonly IMediator mediator;

        public TaskController(ITaskQueries taskQueries, ITraceHolder traceHolder, IMediator mediator)
            : base(traceHolder)
        {
            this.taskQueries = taskQueries;
            this.mediator = mediator;
        }

        /// <summary>
        /// Получить задачи с параметрами пагинации
        /// </summary>
        /// <param name="id">Номер задачи</param>
        /// <returns></returns>
        [HttpGet("Tasks")]
        public async Task<IActionResult> Get(int take, int skip)
        {
            var tasks = await taskQueries.GetTasks(take, skip);

            return OkApi(tasks);
        }

        /// <summary>
        /// Получить задачу по номеру
        /// </summary>
        /// <param name="id">Номер задачи</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var task = await taskQueries.GetTask(id);

            return OkApi(task);
        }

        /// <summary>
        /// Добавление таски
        /// с файлами
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]AddTaskRequest request)
        {
            var addedTaskResponse = await mediator.Send(new AddTaskCommand
            {
                Files = request.Files,
                Name = request.Name
            });

            return OkApi(addedTaskResponse);
        }

        /// <summary>
        /// Апдейт таски
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTaskRequest request)
        {
            var updatedTaskResponse = await mediator.Send(new UpdateTaskCommand
            {
                Id = request.Id,
                Name = request.Name
            });

            return OkApi(updatedTaskResponse);
        }

        /// <summary>
        /// Удаление таски
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Deleted([FromBody] RemoveTaskRequest request)
        {
            var removedTaskResponse = await mediator.Send(new RemoveTaskCommand
            {
                Id = request.Id
            });

            return OkApi(removedTaskResponse);
        }

    }
}
