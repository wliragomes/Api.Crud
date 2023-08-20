using Application.DTOs;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<bool> Add(ClienteDto addCountryDto);
        Task<ClienteDto> GetById(Guid id);
        Task<PaginationResponse<ClienteGetFilterQueryDto>> GetFilter(PaginationRequest paginationRequest);
    }
}
