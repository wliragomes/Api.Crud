﻿using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente cliente);
        Task SaveChangesAsync();
    }
}