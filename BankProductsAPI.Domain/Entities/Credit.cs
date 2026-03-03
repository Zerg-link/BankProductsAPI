// BankProductsAPI.Domain/Entities/Credit.cs


namespace BankProductsAPI.Domain.Entities
{
    /// <summary>
    /// Класс описывает информацию о кредите.
    /// </summary>
    public class Credit
    {
        /// <summary>
        /// Уникальный идентификатор кредита.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор связанного с кредитом клиента.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Навигационное свойство: клиент, которому принадлежит кредит.
        /// </summary>
        public Client Client { get; set; }

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
        public string Currency { get; set; }

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
        public string Type { get; set; }

        /// <summary>
        /// Статус кредита: открыт или закрыт.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Статус кредита: просрочена выплата или нет.
        /// </summary>
        public bool IsExpired { get; set; }

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
