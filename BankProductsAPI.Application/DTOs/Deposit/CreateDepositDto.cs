// BankProductsAPI.Application/Deposit/CreateDepositDto.cs


using BankProductsAPI.Domain.Enums;

namespace BankProductsAPI.Application.DTOs.Deposit
{
    /// <summary>
    /// Класс, описывающий, какие данные показываются при создании депозита.
    /// </summary>
    public class CreateDepositDto
    {
        /// <summary>
        /// Название депозита.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сумма денег на счёте депозита.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Валюта, в которой содержится депозит.
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// Длительность депозита в месяцах.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Процент депозита.
        /// </summary>
        public decimal InterestRate { get; set; }

        /// <summary>
        /// Тип депозита.
        /// </summary>
        public DepositType Type { get; set; }
    }
}
