using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class ProdutoTipoMap : EntityTypeConfiguration<ProdutoTipo>
    {
        public ProdutoTipoMap()
        {
            // Primary Key
            this.HasKey(t => t.ProdutoTipoId);

            // Properties
            this.Property(t => t.NomeProdutoTipo)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ProdutoTipo");
            this.Property(t => t.ProdutoTipoId).HasColumnName("ProdutoTipoId");
            this.Property(t => t.NomeProdutoTipo).HasColumnName("NomeProdutoTipo");
            this.Property(t => t.Ativo).HasColumnName("Ativo");
        }
    }
}
