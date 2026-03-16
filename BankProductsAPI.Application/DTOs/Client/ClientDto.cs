// BankProductsAPI.Application/Client/ClientDto.cs


namespace BankProductsAPI.Application.DTOs.Client
{
    /// <summary>
    /// Класс, описывающий, какие данные показываются, после создания клиента.
    /// </summary>
    public class ClientDto
    {
        /// <summary>
        /// Уникальный идентификатор клиента в базе данных.
        /// </summary>
        public int Id { get; set; }

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
        /// Кредитный рейтинг.
        /// </summary>
        public int CreditRating { get; set; }

        /// <summary>
        /// Дата регистрации в базе данных.
        /// </summary>
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// Электронная почта.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Номер мобильного телефона.
        /// </summary>
        public string? PhoneNumber { get; set; }

    }
}
