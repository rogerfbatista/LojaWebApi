using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class ProdutoEstoqueMap : EntityTypeConfiguration<ProdutoEstoque>
    {
        public ProdutoEstoqueMap()
        {
            // Primary Key
            this.HasKey(t => t.ProdutoEstoqueId);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProdutoEstoque");
            this.Property(t => t.ProdutoEstoqueId).HasColumnName("ProdutoEstoqueId");
            this.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            this.Property(t => t.ProdutoId).HasColumnName("ProdutoId");
            this.Property(t => t.QuantidadeEstoque).HasColumnName("QuantidadeEstoque");
            this.Property(t => t.ValorVenda).HasColumnName("ValorVenda");
            this.Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            this.HasOptional(t => t.Empresa)
                .WithMany(t => t.ProdutoEstoques)
                .HasForeignKey(d => d.EmpresaId);
            this.HasOptional(t => t.Produto)
                .WithMany(t => t.ProdutoEstoques)
                .HasForeignKey(d => d.ProdutoId);

        }
    }
}
