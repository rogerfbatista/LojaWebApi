using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class ProdutoClienteSaidaItemMap : EntityTypeConfiguration<ProdutoClienteSaidaItem>
    {
        public ProdutoClienteSaidaItemMap()
        {
            // Primary Key
            this.HasKey(t => t.ProdutoClienteSaidaItemId);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProdutoClienteSaidaItem");
            this.Property(t => t.ProdutoClienteSaidaItemId).HasColumnName("ProdutoClienteSaidaItemId");
            this.Property(t => t.ProdutoClienteSaidaId).HasColumnName("ProdutoClienteSaidaId");
            this.Property(t => t.ProdutoId).HasColumnName("ProdutoId");
            this.Property(t => t.ClienteId).HasColumnName("ClienteId");
            this.Property(t => t.QuantidadeSaida).HasColumnName("QuantidadeSaida");
            this.Property(t => t.SubTotal).HasColumnName("SubTotal");
            this.Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            this.HasOptional(t => t.Cliente)
                .WithMany(t => t.ProdutoClienteSaidaItems)
                .HasForeignKey(d => d.ClienteId);
            this.HasOptional(t => t.Produto)
                .WithMany(t => t.ProdutoClienteSaidaItems)
                .HasForeignKey(d => d.ProdutoId);
            this.HasOptional(t => t.ProdutoClienteSaida)
                .WithMany(t => t.ProdutoClienteSaidaItems)
                .HasForeignKey(d => d.ProdutoClienteSaidaId);

        }
    }
}
