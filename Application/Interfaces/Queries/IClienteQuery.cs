using Application.DTOs;

namespace Application.Interfaces.Queries
{
    public interface IClienteQuery
    {
        Task<PaginationResponse<ClienteGetFilterQueryDto>> GetFilter(PaginationRequest paginationRequest);
    }
}
