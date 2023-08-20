using Application.DTOs;

namespace Application.Interfaces.Queries
{
    public interface IClienteQuery
    {
        Task<PaginationResponse<ClienteDto>> GetFilter(PaginationRequest paginationRequest);
        Task<ClienteDto> GetById(Guid id);
    }
}
