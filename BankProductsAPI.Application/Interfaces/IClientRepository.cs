// BankProductsAPI.Application/Interfaces.IClientRepository.cs


using BankProductsAPI.Domain.Entities;

namespace BankProductsAPI.Application.Interfaces
{
    /// <summary>
    /// Интерфейс-CRUD для клиентов.
    /// </summary>
    public interface IClientRepository
    {
        Task<Client?> GetByIdAsync(int id);
        Task<IEnumerable<Client>> GetAllAsync();
        Task AddAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(int id);
    }
}