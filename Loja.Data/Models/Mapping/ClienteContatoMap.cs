using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;


namespace Loja.Data.Models.Mapping
{
    public class ClienteContatoMap : EntityTypeConfiguration<ClienteContato>
    {
        public ClienteContatoMap()
        {
            // Primary Key
            HasKey(t => t.ClienteContatoId);

            // Properties
            Property(t => t.Email)
                .HasMaxLength(30);

            Property(t => t.Telefone)
                .HasMaxLength(30);

            // Table & Column Mappings
            ToTable("ClienteContato");
            Property(t => t.ClienteContatoId).HasColumnName("ClienteContatoId");
            Property(t => t.ClienteId).HasColumnName("ClienteId");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.Telefone).HasColumnName("Telefone");
            Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            HasOptional(t => t.Cliente)
                .WithMany(t => t.ClienteContatos)
                .HasForeignKey(d => d.ClienteId);

        }
    }
}
