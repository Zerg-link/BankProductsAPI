// BankProductsAPI.Infrastructure/Repositories/DepositRepository.cs


using BankProductsAPI.Application.Interfaces;
using BankProductsAPI.Domain.Entities;
using BankProductsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankProductsAPI.Infrastructure.Repositories
{
    /// <summary>
    /// Класс, реализующий методы интерфейса по вкладам. Работает по CRUD с базой данных.
    /// </summary>
    public class DepositRepository : IDepositRepository
    {
        private readonly AppDbContext _context;

        public DepositRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Deposit?> GetByIdAsync(int id)
        {
            return await _context.Deposits
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Deposit>> GetAllAsync()
        {
            return await _context.Deposits
                .ToListAsync();
        }

        public async Task AddAsync(Deposit deposit)
        {
            await _context.Deposits.AddAsync(deposit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Deposit deposit)
        {
            _context.Deposits.Update(deposit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deposit = await GetByIdAsync(id);
            if (deposit != null)
            {
                _context.Deposits.Remove(deposit);
                await _context.SaveChangesAsync();
            }
        }
    }
}
