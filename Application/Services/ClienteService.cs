using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Queries;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteQuery _clienteQuery;
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteQuery clienteQuery, IClienteRepository clienteRepository) 
        {
            _clienteQuery = clienteQuery;
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Add(ClienteDto clienteDto)
        {
            var cliente = new Cliente
            {
                Id = new Guid(),
                CPF = clienteDto.CPF,
                Nome = clienteDto.Nome,
                Email = clienteDto.Email,
            };

            _clienteRepository.AddAsync(cliente);
            await _clienteRepository.SaveChangesAsync();

            return true;
        }


        public async Task<ClienteDto> GetById(Guid id)
        {
            return await _clienteQuery.GetById(id);
        }

        public async Task<PaginationResponse<ClienteGetFilterQueryDto>> GetFilter(PaginationRequest paginationRequest)
        {
            return await _clienteQuery.GetFilter(paginationRequest);
        }
    }
}
