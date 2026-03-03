// BankProductsAPI.Domain/Entities/Deposit.cs


namespace BankProductsAPI.Domain.Entities
{
    /// <summary>
    /// Класс описывает информацию о депозите (вкладе).
    /// </summary>
    public class Deposit
    {
        /// <summary>
        /// Уникальный идентификатор депозита.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор связанного с депозитом клиента.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Навигационное свойство: клиент, которому принадлежит депозит.
        /// </summary>
        public Client Client { get; set; }

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
        public string Currency {  get; set; }

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
        public string Type { get; set; }

        /// <summary>
        /// Статус депозита: открыт или закрыт.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Дата создания депозита.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата окончания депозита.
        /// </summary>
        public DateTime ExpiresAt { get; set; }

    }
}
