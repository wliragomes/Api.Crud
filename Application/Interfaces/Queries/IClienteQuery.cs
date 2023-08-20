using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces.Queries
{
    public interface IClienteQuery
    {
        Task<List<Cliente>> Get();
        Task<PaginationResponse<ClienteDto>> GetFilter(PaginationRequest paginationRequest);
        Task<ClienteDto> GetById(Guid id);
    }
}
