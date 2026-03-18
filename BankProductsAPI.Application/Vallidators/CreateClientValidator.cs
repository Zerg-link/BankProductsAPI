// BankProductsAPI.Application/Validators/CreateClientValidator.cs


using FluentValidation;
using BankProductsAPI.Application.DTOs.Client;

namespace BankProductsAPI.Application.Validators
{
    /// <summary>
    /// Валидатор, проверяющий правильность вводимых данных при создании клиента.
    /// </summary>
    public class CreateClientValidator : AbstractValidator<CreateClientDto>
    {
        public CreateClientValidator() 
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Имя обязательно")
                .MaximumLength(50).WithMessage("Имя не длиннее 50 символов");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Фамилия обязательна")
                .MaximumLength(50).WithMessage("Фамилия не длиннее 50 символов");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => x.Email != null)
                .WithMessage("Некорректный email");

            RuleFor(x => x.Snils)
                .NotEmpty().WithMessage("СНИЛС обязателен")
                .Length(11).WithMessage("СНИЛС должен быть длинной в 11 цифр");

            RuleFor(x => x.Inn)
                .NotEmpty().WithMessage("ИНН обязателен")
                .Length(12).WithMessage("ИНН должен быть длинной в 12 цифр");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Пароль обязателен")
                .MinimumLength(8).WithMessage("Пароль минимум 8 символов");

            RuleFor(x => x.Passport)
                .NotNull().WithMessage("Паспортные данные обязательны");
        }
    }
}
