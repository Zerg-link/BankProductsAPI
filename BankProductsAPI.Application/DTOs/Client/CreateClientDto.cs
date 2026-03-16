// BankProductsAPI.Application/Client/CreateClientDto.cs


using BankProductsAPI.Domain.Enums;

namespace BankProductsAPI.Application.DTOs.Client
{
    /// <summary>
    /// Класс, описывающий: какие данные вводятся пользователем для создания нового клиента.
    /// </summary>
    public class CreateClientDto
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Электронная почта.
        /// </summary>
        public string? Email { get; set; }


        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Номер мобильного телефона.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// СНИЛС.
        /// </summary>
        public string Snils { get; set; }

        /// <summary>
        /// ИНН.
        /// </summary>
        public string Inn { get; set; }

        /// <summary>
        /// DTO для создания паспорта.
        /// </summary>
        public CreatePassportDto Passport { get; set; }
    }
}
