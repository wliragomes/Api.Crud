using Application.DTOs;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<PaginationResponse<ClienteGetFilterQueryDto>> GetFilter(PaginationRequest paginationRequest);
    }
}
