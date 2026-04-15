// BankProductsAPI.Infrastructure/Repositories/ApplicationRepository.cs


using BankProductsAPI.Application.Interfaces;
using BankProductsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankProductsAPI.Infrastructure.Repositories
{
    /// <summary>
    /// Класс, реализующий методы интерфейса по заявлениям. Работает по CRUD с базой данных.
    /// </summary>
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _context;

        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Application?> GetByIdAsync(int id)
        {
            return await _context.Applications
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Domain.Entities.Application>> GetAllAsync()
        {
            return await _context.Applications
                .ToListAsync();
        }

        public async Task AddAsync(Domain.Entities.Application application)
        {
            await _context.Applications.AddAsync(application);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.Entities.Application application)
        {
            _context.Applications.Update(application);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var application = await GetByIdAsync(id);
            if (application != null)
            {
                _context.Applications.Remove(application);
                await _context.SaveChangesAsync();
            }
        }
    }
}
