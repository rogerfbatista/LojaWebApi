using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class FornecedorContatoMap : EntityTypeConfiguration<FornecedorContato>
    {
        public FornecedorContatoMap()
        {
            // Primary Key
            this.HasKey(t => t.FornecedorContatoId);

            // Properties
            this.Property(t => t.Email)
                .HasMaxLength(30);

            this.Property(t => t.Telefone)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("FornecedorContato");
            this.Property(t => t.FornecedorContatoId).HasColumnName("FornecedorContatoId");
            this.Property(t => t.FornecedorId).HasColumnName("FornecedorId");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            this.HasOptional(t => t.Fornecedor)
                .WithMany(t => t.FornecedorContatoes)
                .HasForeignKey(d => d.FornecedorId);

        }
    }
}
