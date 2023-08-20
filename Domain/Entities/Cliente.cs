namespace Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string CPF { get; private set; }
        public string Nome { get; private set; }
        public string? Email { get; private set; }

        public Cliente()
        {
            CPF = string.Empty;
            Nome = string.Empty;
        }

        public Cliente(Guid id, string cpf, string nome, string? email)
        {
            Id = id;
            CPF = cpf;
            Nome = nome;
            Email = email;
        }
    }
}
