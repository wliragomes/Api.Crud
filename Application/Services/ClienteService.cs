using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Queries;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteQuery _clienteQuery;
        public ClienteService(IClienteQuery clienteQuery) 
        {
            _clienteQuery = clienteQuery;
        }

        public async Task<PaginationResponse<ClienteGetFilterQueryDto>> GetFilter(PaginationRequest paginationRequest)
        {
            return await _clienteQuery.GetFilter(paginationRequest);
        }
    }
}
