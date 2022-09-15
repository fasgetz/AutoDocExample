using AutoDoc.Utils.Validation.ValidationRules;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Models.Requests.Tasks
{
    public class UpdateTaskRequest
    {
        /// <summary>
        /// Номер задачи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название таски
        /// </summary>
        public string? Name { get; set; }
    }

    public class UpdateTaskRequestValidator : AbstractValidator<UpdateTaskRequest>
    {
        public UpdateTaskRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNullEmpty("Название таски должно быть заполнено");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Название задачи не должно превышать 100 символов");
        }
    }
}
