using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;

namespace Loja.Data.Models.Mapping
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
            this.Property(t => t.QuantidadeSaida).HasColumnName("QuantidadeSaida");
            this.Property(t => t.SubTotal).HasColumnName("SubTotal");
            this.Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
           

            this.HasOptional(t => t.Produto)
                .WithMany(t => t.ProdutoClienteSaidaItems)
                .HasForeignKey(d => d.ProdutoId);
            this.HasOptional(t => t.ProdutoClienteSaida)
                .WithMany(t => t.ProdutoClienteSaidaItems)
                .HasForeignKey(d => d.ProdutoClienteSaidaId);

        }
    }
}
