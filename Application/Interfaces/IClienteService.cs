using Application.DTOs;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<bool> Add(AddClienteDto addCountryDto);
        Task Update(Guid id, UpdateClienteDto clienteDto);
        Task<PaginationResponse<ClienteDto>> GetFilter(PaginationRequest paginationRequest);
        Task<ClienteDto> GetById(Guid id);
    }
}