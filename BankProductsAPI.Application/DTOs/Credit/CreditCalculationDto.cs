// BankProductsAPI/Application/DTOs/Credit/CreditCalculationDto.cs


namespace BankProductsAPI.Application.DTOs.Credit
{
    /// <summary>
    /// Класс, содержащий информацию о денежной части кредита.
    /// </summary>
    public class CreditCalculationDto
    {
        /// <summary>
        /// Сумма, на которую брали кредит.
        /// </summary>
        public decimal OriginalAmount { get; set; }

        /// <summary>
        /// Сумма, в итоге которую клиент заплатил для закрытия кредита.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Сумма, которую клиент переплатил для обслуживания кредита.
        /// </summary>
        public decimal Overpayment { get; set; }

        /// <summary>
        /// Значение ежемесячного платежа для обсуживания кредита.
        /// </summary>
        public decimal MonthlyPayment { get; set; }
    }
}
