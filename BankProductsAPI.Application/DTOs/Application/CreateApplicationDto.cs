// BankProductsAPI.Application/Application/CreateApplicationDto.cs


using BankProductsAPI.Domain.Enums;

namespace BankProductsAPI.Application.DTOs.Application
{
    /// <summary>
    /// Класс, описывающий: какие данные вводятся пользователем для создания нового заявления.
    /// </summary>
    public class CreateApplicationDto
    {
        /// <summary>
        /// Описание заявления.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// На какую сумму денег пишется заявление.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Тип заявления.
        /// </summary>
        public ApplicationType Type { get; set; }
    }
}
