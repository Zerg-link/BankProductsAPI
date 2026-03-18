// BankProductsAPI.Application/Validators/CreateDepositValidator.cs


using BankProductsAPI.Application.DTOs.Deposit;
using FluentValidation;

namespace BankProductsAPI.Application.Validators
{
    /// <summary>
    /// Валидатор, проверяющий правильность вводимых данных при создании вклада (депозита).
    /// </summary>
    public class CreateDepositValidator : AbstractValidator<CreateDepositDto>
    {
        public CreateDepositValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Название вклада обязательно")
                .MaximumLength(100).WithMessage("Название вклада должно быть меньше 100 символов");

            RuleFor(x => x.Duration)
                .NotEmpty().WithMessage("Длительность должна быть указана")
                .LessThan(200).WithMessage("Длительность вклада должна быть меньше 200 месяцев")
                .GreaterThan(0).WithMessage("Длительность вклада должна быть больше чем 0 месяцев");

            RuleFor(x => x.Currency)
                .NotEmpty().WithMessage("Валюта вклада должна быть указана");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Общая сумма вклада должна быть указана")
                .GreaterThan(0).WithMessage("Общая сумма вклада должна быть указана");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Тип вклада должен быть указан");

            RuleFor(x => x.InterestRate)
                  .NotEmpty().WithMessage("Процент вклада должен быть указан")
                  .GreaterThan(0).WithMessage("Процент вклада долено быть больше 0");
        }
    }
}
