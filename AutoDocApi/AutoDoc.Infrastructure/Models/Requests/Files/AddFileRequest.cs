using AutoDoc.Utils.Validation.CustomValidation;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Models.Requests.Files
{
    /// <summary>
    /// Запрос на добавление файла задаче
    /// </summary>
    public class AddFileRequest
    {
        /// <summary>
        /// Номер задачи
        /// </summary>
        public int IdTask { get; set; }

        /// <summary>
        /// Файл
        /// </summary>
        public IFormFile File { get; set; }
    }

    public class AddFileRequestValidator : AbstractValidator<AddFileRequest>
    {
        public AddFileRequestValidator()
        {
            RuleFor(x => x.File)
                .SetValidator(new FileValidation());
        }
    }
}
