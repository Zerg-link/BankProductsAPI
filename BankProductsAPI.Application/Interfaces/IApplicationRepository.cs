// BankProductsAPI.Application/Interfaces.IApplicationRepository.cs


using BankProductsAPI.Domain.Entities;

namespace BankProductsAPI.Application.Interfaces
{
    /// <summary>
    /// Интерфейс-CRUD для заявлений.
    /// </summary>
    public interface IApplicationRepository
    {
        Task<Domain.Entities.Application?> GetByIdAsync(int id);
        Task<IEnumerable<Domain.Entities.Application>> GetAllAsync();
        Task AddAsync(Domain.Entities.Application application);
        Task UpdateAsync(Domain.Entities.Application application);
        Task DeleteAsync(int id);
    }
}
