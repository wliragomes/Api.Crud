using Application.DTOs;

namespace Application.Interfaces.Queries
{
    public interface IClienteQuery
    {
        Task<ClienteDto> GetById(Guid id);
        Task<PaginationResponse<ClienteDto>> GetFilter(PaginationRequest paginationRequest);
    }
}
