using Application.DTOs;
using Application.Interfaces.Queries;
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

        public async Task<ClienteDto> GetById(Guid id)
        {
            var cliente = await _dbContext.Cliente
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return null; // Retorna null se o cliente não for encontrado.
            }

            // Mapeie o objeto 'cliente' para um 'ClienteDto' usando algum método de mapeamento (por exemplo, AutoMapper).
            var clienteDto = new ClienteDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                // Mapeie outras propriedades, se necessário.
            };

            return clienteDto;
        }

        public async Task<PaginationResponse<ClienteGetFilterQueryDto>> GetFilter(PaginationRequest paginationRequest)
        {
            var query = _dbContext.Cliente.AsNoTracking();

            var data = await query
                .Select(c => new ClienteGetFilterQueryDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Email = c.Email

                })
                .ToListAsync();

            var paginationResponse = new PaginationResponse<ClienteGetFilterQueryDto>
            {
                PageNumber = paginationRequest.PageNumber,
                PageSize = paginationRequest.PageSize,
                TotalItems = data.Count,
                Data = data,
            };

            return paginationResponse;
        }
    }
}
