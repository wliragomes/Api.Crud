namespace Application.DTOs
{
    public class AddClienteDto
    {
        public required string CPF { get; set; }
        public required string Nome { get; set; }
        public string? Email { get; set; }
    }
}
