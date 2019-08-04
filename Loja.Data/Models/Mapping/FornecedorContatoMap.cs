

using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;

namespace Loja.Data.Models.Mapping
{
    public class FornecedorContatoMap : EntityTypeConfiguration<FornecedorContato>
    {
        public FornecedorContatoMap()
        {
            // Primary Key
            HasKey(t => t.FornecedorContatoId);

            // Properties
            Property(t => t.Email)
                .HasMaxLength(30);

            Property(t => t.Telefone)
                .HasMaxLength(30);

            // Table & Column Mappings
            ToTable("FornecedorContato");
            Property(t => t.FornecedorContatoId).HasColumnName("FornecedorContatoId");
            Property(t => t.FornecedorId).HasColumnName("FornecedorId");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.Telefone).HasColumnName("Telefone");
            Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            HasOptional(t => t.Fornecedor)
                .WithMany(t => t.FornecedorContatos)
                .HasForeignKey(d => d.FornecedorId);

        }
    }
}
