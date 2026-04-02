// BankProductsAPI.Application/Interfaces.IDepositRepository.cs


using BankProductsAPI.Domain.Entities;

namespace BankProductsAPI.Application.Interfaces
{
    /// <summary>
    /// Интерфейс-CRUD для вкладов.
    /// </summary>
    public interface IDepositRepository
    {
        Task<Deposit?> GetByIdAsync(int id);
        Task<IEnumerable<Deposit>> GetAllAsync();
        Task AddAsync(Deposit deposit);
        Task UpdateAsync(Deposit deposit);
        Task DeleteAsync(int id);

    }
}
