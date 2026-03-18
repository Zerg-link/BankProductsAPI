// BankProductsAPI.Application/Validators/CreateCreditValidator.cs

using BankProductsAPI.Application.DTOs.Credit;
using FluentValidation;

namespace BankProductsAPI.Application.Validators
{
    /// <summary>
    /// Валидатор, проверяющий правильность вводимых данных при создании кредита.
    /// </summary>
    public class CreateCreditValidator : AbstractValidator<CreateCreditDto>
    {
        public CreateCreditValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Название кредита обязательно")
                .MaximumLength(100).WithMessage("Название кредита должно быть меньше 100 символов");

            RuleFor(x => x.Duration)
                .NotEmpty().WithMessage("Длительность должна быть указана")
                .LessThan(200).WithMessage("Длительность кредита должна быть меньше 200 месяцев")
                .GreaterThan(0).WithMessage("Длительность кредита должна быть больше чем 0 месяцев");

            RuleFor(x => x.Currency)
                .NotEmpty().WithMessage("Валюта кредита должна быть указана");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Общая сумма кредита должна быть указана")
                .GreaterThan(0).WithMessage("Общая сумма кредита должна быть больше 0");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Тип кредита должен быть указан");

            RuleFor(x => x.InterestRate)
                  .NotEmpty().WithMessage("Процент кредита должен быть указан")
                  .GreaterThan(0).WithMessage("Процент кредита должно быть больше 0");


        }
    }
}
