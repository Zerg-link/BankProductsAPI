// BankProductsAPI.Application/Credit/CreateCreditDto.cs


using BankProductsAPI.Domain.Enums;

namespace BankProductsAPI.Application.DTOs.Credit
{
    /// <summary>
    /// Класс, описывающий: какие данные вводятся пользователем для создания нового кредита.
    /// </summary>
    public class CreateCreditDto
    {
        /// <summary>
        /// Название кредита.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Общая сумма выданного кредита.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Валюта, в которой содержится кредит.
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// Длительность кредита в месяцах.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Процент кредита.
        /// </summary>
        public decimal InterestRate { get; set; }

        /// <summary>
        /// Тип кредита.
        /// </summary>
        public CreditType Type { get; set; }
    }
}
