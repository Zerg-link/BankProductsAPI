// BankProductsAPI.Infrastructure/AppDbContext.cs


using BankProductsAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankProductsAPI.Infrastructure.Data
{
    /// <summary>
    /// Класс, описывающий базу данных. 
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Конструктор, принимающий таблицы базы данных и передающий их в AppDbContext.
        /// </summary>
        /// <param name="options"> Настройки подключения к базе данных. </param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Таблица со всеми заявлениями из базы данных.
        /// </summary>
        public DbSet<Application> Applications { get; set; }

        /// <summary>
        /// Таблица со всеми клиентами из базы данных.
        /// </summary>
        public DbSet<Client> Clients { get; set; }

        /// <summary>
        /// Таблица со всеми кредитами из базы данных.
        /// </summary>
        public DbSet<Credit> Credits { get; set; }

        /// <summary>
        /// Таблица со всеми депозитами (вкладами) из базы данных.
        /// </summary>
        public DbSet<Deposit> Deposits { get; set; }

        /// <summary>
        /// Таблица со всеми паспортами из базы данных.
        /// </summary>
        public DbSet<Passport> Passports { get; set; }
    }
}
