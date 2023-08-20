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

        public async Task<bool> Add(AddClienteDto addClienteDto)
        {
            var cliente = new Cliente(new Guid(), addClienteDto.CPF, addClienteDto.Nome, addClienteDto.Email);

            await _clienteRepository.AddAsync(cliente);
            await _clienteRepository.SaveChangesAsync();

            return true;
        }

        public async Task Update(Guid id, UpdateClienteDto clienteDto)
        {
            var cliente = await _clienteQuery.GetById(id);

            if (cliente == null)
                throw new ArgumentException("Cliente não encontrado");

            var updateCliente = new Cliente(id, clienteDto.CPF, clienteDto.Nome, clienteDto.Email);

            await _clienteRepository.UpdateAsync(updateCliente);
            await _clienteRepository.SaveChangesAsync();
        }

        public async Task<PaginationResponse<ClienteDto>> GetFilter(PaginationRequest paginationRequest)
        {
            return await _clienteQuery.GetFilter(paginationRequest);
        }

        public async Task<ClienteDto> GetById(Guid id)
        {
            return await _clienteQuery.GetById(id);
        }
    }
}
