using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Utils.Validation.CustomValidation
{
    /// <summary>
    /// Валидация файла
    /// Размер должен быть < 100 МБ
    /// </summary>
    public class FileValidation : AbstractValidator<IFormFile>
    {
        public FileValidation()
        {
            RuleFor(x => x)
                .Must(e => (e.Length / 1024 / 1024) < 5)
                .WithMessage("Размер файла должен быть меньше 5 мб");
        }
    }
}
