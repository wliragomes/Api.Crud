using Application.DTOs;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<bool> Add(AddUpdateClienteDto addCountryDto);
        Task Update(Guid id, AddUpdateClienteDto clienteDto);
        Task<bool> Delete(Guid id);
        Task<PaginationResponse<ClienteDto>> GetFilter(PaginationRequest paginationRequest);
        Task<ClienteDto> GetById(Guid id);
    }
}