// BankProductsAPI.Application/Interfaces.ICreditRepository.cs


using BankProductsAPI.Domain.Entities;

namespace BankProductsAPI.Application.Interfaces
{
    /// <summary>
    /// Интерфейс-CRUD для кредитов.
    /// </summary>
    public interface ICreditRepository
    {
        Task<Credit?> GetByIdAsync(int id);
        Task<IEnumerable<Credit>> GetAllAsync();
        Task AddAsync(Credit credit);
        Task UpdateAsync(Credit credit);
        Task DeleteAsync(int id);
    }
}
