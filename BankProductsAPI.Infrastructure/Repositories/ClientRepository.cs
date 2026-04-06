// BankProductsAPI.Infrastructure/Repositories/ClientRepository.cs


using BankProductsAPI.Application.Interfaces;
using BankProductsAPI.Domain.Entities;
using BankProductsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankProductsAPI.Infrastructure.Repositories
{
    /// <summary>
    /// Класс, реализующий методы интерфейса по клиентам. Работает по CRUD с базой данных.
    /// </summary>
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _context.Clients
                .Include(c => c.PassportInfo)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients
                .Include(c => c.PassportInfo)
                .ToListAsync();
        }

        public async Task AddAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var client = await GetByIdAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Client?> GetByEmailAsync(string email)
        {
            return await _context.Clients
                .Include(c => c.PassportInfo)
                .FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
