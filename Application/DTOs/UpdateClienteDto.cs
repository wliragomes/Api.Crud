namespace Application.DTOs
{
    public class UpdateClienteDto
    {
        public Guid Id { get; set; }
        public required string CPF { get; set; }
        public required string Nome { get; set; }
        public string? Email { get; set; }
    }
}
