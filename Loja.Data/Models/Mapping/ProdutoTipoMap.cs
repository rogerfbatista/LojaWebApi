using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;


namespace Loja.Data.Models.Mapping
{
    public class ProdutoTipoMap : EntityTypeConfiguration<ProdutoTipo>
    {
        public ProdutoTipoMap()
        {
            // Primary Key
            HasKey(t => t.ProdutoTipoId);

            // Properties
            Property(t => t.NomeProdutoTipo)
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("ProdutoTipo");
            Property(t => t.ProdutoTipoId).HasColumnName("ProdutoTipoId");
            Property(t => t.NomeProdutoTipo).HasColumnName("NomeProdutoTipo");
            Property(t => t.Ativo).HasColumnName("Ativo");
        }
    }
}
