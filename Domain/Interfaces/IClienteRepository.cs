using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente cliente);
        Task Update(Cliente cliente);
        Task<bool> DeleteById(Guid Id);
        Task SaveChangesAsync();
    }
}
