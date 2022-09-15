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
    /// Запрос на обновление файла
    /// </summary>
    public class UpdateFileRequest
    {
        /// <summary>
        /// Номер файла
        /// </summary>
        public int IdFile { get; set; }

        /// <summary>
        /// Файл
        /// </summary>
        public IFormFile File { get; set; }
    }

    public class UpdateFileRequestValidator : AbstractValidator<UpdateFileRequest>
    {
        public UpdateFileRequestValidator()
        {
            RuleFor(x => x.File)
                .SetValidator(new FileValidation());
        }
    }
}
