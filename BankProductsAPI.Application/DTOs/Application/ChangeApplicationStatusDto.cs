// BankProductsAPI/Application/DTO's/Application/ChangeApplicationStatusDto.cs


using BankProductsAPI.Domain.Enums;

namespace BankProductsAPI.Application.DTOs.Application
{
    /// <summary>
    /// Класс, описывающий информацию, необходимую для перевода заявления в новый статус.
    /// </summary>
    public class ChangeApplicationStatusDto
    {
        /// <summary>
        /// Новый статус заявления.
        /// </summary>
        public ApplicationStatus NewStatus { get; set; }

        /// <summary>
        /// Комментарий менеджера.
        /// </summary>
        public string? ManagerComment { get; set; }
    }
}
