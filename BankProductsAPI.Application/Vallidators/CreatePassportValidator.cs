// BankProductsAPI.Application/Validators/CreatePassportValidator.cs



using BankProductsAPI.Application.DTOs.Client;
using FluentValidation;

namespace BankProductsAPI.Application.Validators
{
    /// <summary>
    /// Валидатор, проверяющий правильность вводимых данных при создании паспорта.
    /// </summary>
    public class CreatePassportValidator : AbstractValidator<CreatePassportDto>
    {
        public CreatePassportValidator() 
        {
            RuleFor(x => x.Serial)
                .NotEmpty().WithMessage("Серия паспорта обязательна")
                .Length(4).WithMessage("Серия паспорта должна быть длинной в 4 цифры");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Код обязателен")
                .Length(6).WithMessage("Код должен быть длинной в 6 цифр");

            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Номер паспорта обязателен")
                .Length(6).WithMessage("Номер паспорта должен быть длинной в 6 цифр");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Дата паспорта обязательна");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Пол обязателен");

            RuleFor(x => x.BirthPlace)
                .NotEmpty().WithMessage("Место рождения должно быть указано");

        }
    }
}
