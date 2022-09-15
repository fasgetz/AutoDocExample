using AutoDoc.Infrastructure.Application.Commands.Files.AddFile;
using AutoDoc.Infrastructure.Application.Commands.Files.DownloadFile;
using AutoDoc.Infrastructure.Application.Commands.Files.RemoveFile;
using AutoDoc.Infrastructure.Application.Commands.Files.UpdateFile;
using AutoDoc.Infrastructure.Application.Queries.Files;
using AutoDoc.Infrastructure.Models.Requests.Files;
using AutoDoc.Utils.AspNet.Controllers;
using AutoDoc.Utils.AspNet.DataTypes;
using AutoDoc.Utils.TraceHolder.TraceHolder.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace AutoDoc.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Produces(ContentType.Json)]
    public class FileController : BaseApiController
    {
        private readonly IFileQueries fileQueries;
        private readonly IMediator mediator;

        public FileController(IFileQueries fileQueries, ITraceHolder traceHolder, IMediator mediator)
            : base(traceHolder)
        {
            this.fileQueries = fileQueries;
            this.mediator = mediator;
        }

        /// <summary>
        /// Получить файл по номеру
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetFiles")]
        public async Task<IActionResult> GetFiles(int skip, int take)
        {
            var files = await fileQueries.GetFiles(take, skip);

            return OkApi(files);
        }

        /// <summary>
        /// Получить файл по номеру
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var file = await fileQueries.GetFile(id);

            return OkApi(file);
        }

        /// <summary>
        /// Скачать файл по номеру в бд (ID)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("Download")]
        public async Task<IActionResult> Download(int idFile)
        {
            var findFileResponse = await mediator.Send(new DownloadFileCommand
            {
                IdFile = idFile
            });

            return File(findFileResponse.Bytes, findFileResponse.ContentType, findFileResponse.FileName);
        }

        /// <summary>
        /// Добавление файла
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AddFileRequest request)
        {
            var addedFileResponse = await mediator.Send(new AddFileCommand
            {
                File = request.File,
                IdTask = request.IdTask
            });

            return OkApi(addedFileResponse);
        }

        /// <summary>
        /// Обновление файла (замена)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateFileRequest request)
        {
            var updatedFileResponse = await mediator.Send(new UpdateFileCommand
            {
                File = request.File,
                IdFile = request.IdFile
            });

            return OkApi(updatedFileResponse);
        }

        /// <summary>
        /// Обновление файла (замена)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RemoveFileRequest request)
        {
            var removedFileResponse = await mediator.Send(new RemoveFileCommand
            {
                IdFile = request.IdFile
            });

            return OkApi(removedFileResponse);
        }
    }
}
