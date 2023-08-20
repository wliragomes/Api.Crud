using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> Add(AddClienteDto addCountryDto);
        Task Update(UpdateClienteDto clienteDto);
        Task<bool> Delete(Guid id);
        Task<List<Cliente>> Get();
        Task<PaginationResponse<ClienteDto>> GetFilter(PaginationRequest paginationRequest);
        Task<ClienteDto> GetById(Guid id);
    }
}