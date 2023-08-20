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

        public async Task<Cliente> Add(AddClienteDto addClienteDto)
        {
            var cliente = new Cliente(new Guid(), addClienteDto.CPF, addClienteDto.Nome, addClienteDto.Email);

            await _clienteRepository.AddAsync(cliente);
            await _clienteRepository.SaveChangesAsync();

            return cliente;
        }

        public async Task Update(UpdateClienteDto updateClienteDto)
        {
            var cliente = await _clienteQuery.GetById(updateClienteDto.Id);

            if (cliente == null)
                throw new ArgumentException("Cliente não encontrado");

            var updateCliente = new Cliente(updateClienteDto.Id, updateClienteDto.CPF, updateClienteDto.Nome, updateClienteDto.Email);

            await _clienteRepository.Update(updateCliente);
            await _clienteRepository.SaveChangesAsync();
        }

        public async Task<bool> Delete(Guid Id)
        {
            var retorno = await _clienteRepository.DeleteById(Id);
            await _clienteRepository.SaveChangesAsync();

            return retorno;
        }

        public async Task<List<Cliente>> Get()
        {
            return await _clienteQuery.Get();
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
