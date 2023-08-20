using Application.DTOs;
using Application.Interfaces.Queries;
using Domain.Entities;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Queries
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public ClienteQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cliente?>?> Get()
        {
            var cliente = _dbContext.Cliente.AsNoTracking().ToList();

            if (cliente == null)
                return null;

            return cliente;
        }

        public async Task<PaginationResponse<ClienteDto>> GetFilter(PaginationRequest paginationRequest)
        {
            var query = _dbContext.Cliente.AsNoTracking();

            // Aplicar a paginação antes de carregar os dados
            var paginatedQuery = query
                .Select(c => new ClienteDto
                {
                    Id = c.Id,
                    CPF = c.CPF,
                    Nome = c.Nome,
                    Email = c.Email
                })
                .Skip((paginationRequest.PageNumber - 1) * paginationRequest.PageSize) // Pule registros anteriores
                .Take(paginationRequest.PageSize); // Pegue apenas PageSize registros

            var data = await paginatedQuery.ToListAsync();

            var totalCount = await query.CountAsync(); // Total de itens sem a paginação

            var paginationResponse = new PaginationResponse<ClienteDto>
            {
                PageNumber = paginationRequest.PageNumber,
                PageSize = paginationRequest.PageSize,
                TotalItems = totalCount, // Defina o total de itens sem a paginação
                Data = data,
            };

            return paginationResponse;
        }

        public async Task<ClienteDto?> GetById(Guid id)
        {
            var cliente = await _dbContext.Cliente
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
                return null;

            var clienteDto = new ClienteDto
            {
                Id = cliente.Id,
                CPF = cliente.CPF,
                Nome = cliente.Nome,
                Email = cliente.Email
            };

            return clienteDto;
        }
    }
}
