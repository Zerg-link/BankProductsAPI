// BankProductsAPI.Application/Client/CreatePassportDto.cs


using BankProductsAPI.Domain.Enums;

namespace BankProductsAPI.Application.DTOs.Client
{
    /// <summary>
    /// Класс, описывающий: какие данные вводятся пользователем для создания нового паспорта.
    /// </summary>
    public class CreatePassportDto
    {
        /// <summary>
        /// Номер паспорта.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Серия паспорта.
        /// </summary>
        public string Serial { get; set; }

        /// <summary>
        /// Код подразделения.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Место рождения.
        /// </summary>
        public string BirthPlace { get; set; }

        /// <summary>
        /// Место выдачи паспорта.
        /// </summary>
        public string PassportPlace { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Дата выдачи паспорта.
        /// </summary>
        public DateTime PassportDate { get; set; }

    }
}
