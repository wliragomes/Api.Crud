﻿namespace Application.DTOs
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string? CPF { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
    }
}
