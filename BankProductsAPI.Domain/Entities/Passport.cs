// BankProductsAPI.Domain/Entities/Passport.cs


namespace BankProductsAPI.Domain.Entities
{
    /// <summary>
    /// Класс описывает информацию о паспорте.
    /// </summary>
    public class Passport
    {
        /// <summary>
        /// Идентификатор паспорта в базе данных.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор клиента, которому принадлежит паспорт.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Навигационное свойство: клиент, которому принадлежит паспорт.
        /// </summary>
        public Client Client { get; set; }

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
        public string Gender { get; set; }

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
