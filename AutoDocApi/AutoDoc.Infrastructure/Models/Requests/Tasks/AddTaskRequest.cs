using AutoDoc.Infrastructure.Models.DTO.Files;
using AutoDoc.Utils.Validation.CustomValidation;
using AutoDoc.Utils.Validation.ValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Models.Requests.Tasks
{
    /// <summary>
    /// Запрос на добавление задачи
    /// </summary>
    public class AddTaskRequest
    {
        /// <summary>
        /// Название таски
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Файлы
        /// </summary>
        public ICollection<IFormFile>? Files { get; set; }
    }

    public class AddTaskRequestValidator : AbstractValidator<AddTaskRequest>
    {
        public AddTaskRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNullEmpty("Название таски должно быть заполнено");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Название задачи не должно превышать 100 символов");

            RuleForEach(x => x.Files)
                .SetValidator(new FileValidation());
        }
    }
}
