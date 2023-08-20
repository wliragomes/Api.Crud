namespace Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string CPF { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
    }
}
