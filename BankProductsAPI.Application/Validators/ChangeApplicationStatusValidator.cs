// BankProductsAPI/Application/Validators/ChangeApplicationStatusValidator.cs


using BankProductsAPI.Application.DTOs.Application;
using BankProductsAPI.Domain.Enums;
using FluentValidation;

namespace BankProductsAPI.Application.Vallidators
{
    /// <summary>
    /// Валидатор, проверяющий правильность вводимых данных при изменении статуса заявления.
    /// </summary>
    public class ChangeApplicationStatusValidator : AbstractValidator<ChangeApplicationStatusDto>
    {
        public ChangeApplicationStatusValidator()
        {
            RuleFor(x => x.NewStatus)
                .IsInEnum().WithMessage("Новый статус заявления должен быть указан");

            RuleFor(x => x.ManagerComment)
                .NotEmpty().When(x => x.NewStatus == ApplicationStatus.Approved || x.NewStatus == ApplicationStatus.Rejected)
                .WithMessage("омментарий менеджера обязателен при одобрении или отклонении заявления");
        }
    }
}
