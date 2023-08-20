using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;

namespace Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Cliente entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task Update(Cliente entity)
        {
            _context.Cliente.Update(entity);
        }

        public async Task<bool> DeleteById(Guid Id)
        {
            var pessoa = await _context.Cliente.FindAsync(Id);
            if (pessoa != null)
            {
                _context.Cliente.Remove(pessoa);
                await _context.SaveChangesAsync();
                return true;
            }
            else { return false; }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
