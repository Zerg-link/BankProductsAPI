// BankProductsAPI.Infrastructure/Repositories/CreditRepository.cs


using BankProductsAPI.Application.Interfaces;
using BankProductsAPI.Domain.Entities;
using BankProductsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankProductsAPI.Infrastructure.Repositories
{
    /// <summary>
    /// Класс, реализующий методы интерфейса по кредитам. Работает по CRUD с базой данных.
    /// </summary>
    public class CreditRepository : ICreditRepository
    {
        private readonly AppDbContext _context;

        public CreditRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Credit?> GetByIdAsync(int id)
        {
            return await _context.Credits
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Credit>> GetAllAsync()
        {
            return await _context.Credits
                .ToListAsync();
        }

        public async Task AddAsync(Credit credit)
        {
            await _context.Credits.AddAsync(credit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Credit credit)
        {
            _context.Credits.Update(credit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var credit = await GetByIdAsync(id);
            if (credit != null)
            {
                _context.Credits.Remove(credit);
                await _context.SaveChangesAsync();
            }
        }
    }
}
