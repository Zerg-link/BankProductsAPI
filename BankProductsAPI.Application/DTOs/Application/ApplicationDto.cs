// BankProductsAPI.Application/Application/ApplicationDto.cs


using BankProductsAPI.Domain.Enums;

namespace BankProductsAPI.Application.DTOs.Application
{
    /// <summary>
    /// Класс, описывающий: какие данные показываются после создания заявления.
    /// </summary>
    public class ApplicationDto
    {
        /// <summary>
        /// Уникальный идентификатор заявления.
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Описание заявления.
        /// </summary>
        public string Description { get; set; }

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

        /// <summary>
        /// Тип заявления.
        /// </summary>
        public ApplicationType Type { get; set; }
    }
}
