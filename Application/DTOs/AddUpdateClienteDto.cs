namespace Application.DTOs
{
    public class AddUpdateClienteDto
    {
        public required string CPF { get; set; }
        public required string Nome { get; set; }
        public string? Email { get; set; }
    }
}
