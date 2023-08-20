using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes"); // Nome da tabela no banco de dados.

            // Configuração das propriedades da entidade Cliente.
            builder.HasKey(c => c.Id); // Definindo a chave primária.
            builder.Property(c => c.Id).HasColumnName("ClienteId"); // Nome da coluna no banco de dados.

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(100); // Exemplo: Nome é obrigatório e no máximo 100 caracteres.
            builder.Property(c => c.Email).IsRequired().HasMaxLength(255); // Exemplo: Email é obrigatório e no máximo 255 caracteres.
        }
    }
}
