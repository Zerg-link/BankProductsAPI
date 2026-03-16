// BankProductsAPI.Application/Credit/CreditDto.cs


using BankProductsAPI.Domain.Enums;

namespace BankProductsAPI.Application.DTOs.Credit
{
    /// <summary>
    /// Класс, описывающий: какие данные показываются после создания кредита.
    /// </summary>
    public class CreditDto
    {
        /// <summary>
        /// Уникальный идентификатор кредита.
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// Статус кредита.
        /// </summary>
        public CreditStatus Status { get; set; }

        /// <summary>
        /// Дата создания кредита.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата окончания кредита.
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// Сумма ежемесячной выплаты клиентом.
        /// </summary>
        public decimal MonthlyPayment { get; set; }

        /// <summary>
        /// Сумма, которую клиент уже выплатил.
        /// </summary>
        public decimal PaidAmount { get; set; }
    }
}
