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
