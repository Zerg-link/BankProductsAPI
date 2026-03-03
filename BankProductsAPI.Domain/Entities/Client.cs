// BankProductsAPI.Domain/Entities/Client.cs


namespace BankProductsAPI.Domain.Entities
{
    /// <summary>
    /// Класс описывает: какую информацию необходимо хранить о клиенте.
    /// </summary>
    public class Client
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
        /// Электронная почта.
        /// </summary>
        public string? Email { get; set; }

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
        /// Кредитный рейтинг.
        /// </summary>
        public int CreditRating { get; set; }

        /// <summary>
        /// Дата регистрации в базе данных.
        /// </summary>
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// Данные паспорта.
        /// </summary>
        public Passport PassportInfo { get ; set; }

        /// <summary>
        /// Депозиты (вклады), связанные с данным клиентом.
        /// </summary>
        public ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();

        /// <summary>
        /// Кредиты, связанные с данным клиентом.
        /// </summary>
        public ICollection<Credit> Credits { get; set; } = new List<Credit>();

    }
}
