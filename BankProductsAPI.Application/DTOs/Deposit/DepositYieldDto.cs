// BankProductsAPI/Application/DTOs/Deposit/DepositYieldDto.cs


namespace BankProductsAPI.Application.DTOs.Deposit
{
    /// <summary>
    /// Данный класс описывает всё, что связано с доходностью вклада.
    /// </summary>
    public class DepositYieldDto
    {
        /// <summary>
        /// Сколько денег изначально на вкладе.
        /// </summary>
        public decimal OriginalAmount { get; set; }

        /// <summary>
        /// Сколько денег будет получено при закрытии вклада.
        /// </summary>
        public decimal FinalAmount { get; set; }

        /// <summary>
        /// Какая итоговая выгода от вклада.
        /// </summary>
        public decimal Profit { get; set; }
    }
}
