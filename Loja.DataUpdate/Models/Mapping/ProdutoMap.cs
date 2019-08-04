using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            // Primary Key
            this.HasKey(t => t.ProdutoId);

            // Properties
            this.Property(t => t.CodigoReferencia)
                .HasMaxLength(20);

            this.Property(t => t.NomeProduto)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Produto");
            this.Property(t => t.ProdutoId).HasColumnName("ProdutoId");
            this.Property(t => t.ProdutoTipoId).HasColumnName("ProdutoTipoId");
            this.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            this.Property(t => t.CodigoReferencia).HasColumnName("CodigoReferencia");
            this.Property(t => t.NomeProduto).HasColumnName("NomeProduto");
            this.Property(t => t.DataCastro).HasColumnName("DataCastro");
            this.Property(t => t.ImagemCliente).HasColumnName("ImagemCliente");
            this.Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            this.HasOptional(t => t.ProdutoTipo)
                .WithMany(t => t.Produtoes)
                .HasForeignKey(d => d.ProdutoTipoId);

        }
    }
}
