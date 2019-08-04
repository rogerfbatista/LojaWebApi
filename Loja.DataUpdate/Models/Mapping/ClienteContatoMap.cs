using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class ClienteContatoMap : EntityTypeConfiguration<ClienteContato>
    {
        public ClienteContatoMap()
        {
            // Primary Key
            this.HasKey(t => t.ClienteContatoId);

            // Properties
            this.Property(t => t.Email)
                .HasMaxLength(30);

            this.Property(t => t.Telefone)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("ClienteContato");
            this.Property(t => t.ClienteContatoId).HasColumnName("ClienteContatoId");
            this.Property(t => t.ClienteId).HasColumnName("ClienteId");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            this.HasOptional(t => t.Cliente)
                .WithMany(t => t.ClienteContatoes)
                .HasForeignKey(d => d.ClienteId);

        }
    }
}
