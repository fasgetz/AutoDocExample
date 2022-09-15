using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Utils.Validation.ValidationRules
{
    public static class CommonValidationRules
    {
        public static IRuleBuilderOptions<T, TValue> Positive<T, TValue>(this IRuleBuilder<T, TValue> ruleBuilder) where TValue : IComparable<TValue>
        {
            return ruleBuilder.Must(e => Comparer<TValue>.Default.Compare(e, default) > 0).WithMessage("Значение поля {PropertyName} должно быть больше нуля");
        }

        public static IRuleBuilderOptions<T, TElement> NotNullEmpty<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.Must(e =>
            {
                if (e == null || string.IsNullOrEmpty(e.ToString().Replace("null", null)) == true)
                    return false;

                return true;
            }).WithMessage("Поле {PropertyName} обязательно к заполнению")
                .Configure(c => c.CascadeMode = CascadeMode.Stop);
        }

        public static IRuleBuilderOptions<T, TElement> NotNullEmpty<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, string message)
        {
            return ruleBuilder.Must(e =>
            {
                if (e == null || string.IsNullOrEmpty(e.ToString().Replace("null", null)) == true)
                    return false;

                return true;
            }).WithMessage(message)
                .Configure(c => c.CascadeMode = CascadeMode.Stop);
        }


        public static IRuleBuilderOptions<T, TElement> Required<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.NotEmpty().WithMessage("Поле {PropertyName} обязательно к заполнению")
                .Configure(c => c.CascadeMode = CascadeMode.Stop);
        }

        public static IRuleBuilderOptions<T, TElement> Required<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, string message)
        {
            return ruleBuilder.NotEmpty().WithMessage(message)
                .Configure(c => c.CascadeMode = CascadeMode.Stop);
        }
    }
}
