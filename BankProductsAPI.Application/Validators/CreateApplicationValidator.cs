// BankProductsAPI.Application/Validators/CreateApplicationValidator.cs


using BankProductsAPI.Application.DTOs.Application;
using FluentValidation;

namespace BankProductsAPI.Application.Validators
{

    /// <summary>
    /// Валидатор, проверяющий правильность вводимых данных при создании заявления.
    /// </summary>
    public class CreateApplicationValidator : AbstractValidator<CreateApplicationDto>
    {
        public CreateApplicationValidator() 
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Описание заявление должно быть заполнено");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Сумма денег, на которое пишется заявление, - обязательна")
                .GreaterThan(0).WithMessage("Общая сумма денег у заявления должна быть больше 0");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Тип заявление должен быть указан");


        }
    }
}
