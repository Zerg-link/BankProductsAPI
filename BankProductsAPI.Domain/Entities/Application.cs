// BankProductsAPI.Domain/Entities/Application.cs


using BankProductsAPI.Domain.Enums;

namespace BankProductsAPI.Domain.Entities
{

    /// <summary>
    /// Класс описывает информацию о заявлении.
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Уникальный идентификатор заявления.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор связанного с заявлением клиента.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Навигационное свойство: клиент, которому принадлежит заявление.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Описание заявления.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Тип заявления.
        /// </summary>
        public ApplicationType Type { get; set; }

        /// <summary>
        /// Статус заявления.
        /// </summary>
        public ApplicationStatus Status { get; set; }

        /// <summary>
        /// На какую сумму денег пишется заявление.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Комментарий менеджера: одобрено, отклонено.
        /// </summary>
        public string? ManagerComment { get; set; }

        /// <summary>
        /// Дата создания заявления.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата последнего обновления заявления.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
