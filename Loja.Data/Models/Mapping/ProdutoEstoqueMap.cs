using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;


namespace Loja.Data.Models.Mapping
{
    public class ProdutoEstoqueMap : EntityTypeConfiguration<ProdutoEstoque>
    {
        public ProdutoEstoqueMap()
        {
            // Primary Key
            HasKey(t => t.ProdutoEstoqueId);

            // Properties
            // Table & Column Mappings
            ToTable("ProdutoEstoque");
            Property(t => t.ProdutoEstoqueId).HasColumnName("ProdutoEstoqueId");
            Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            Property(t => t.ProdutoId).HasColumnName("ProdutoId");
            Property(t => t.QuantidadeEstoque).HasColumnName("QuantidadeEstoque");
            Property(t => t.ValorVenda).HasColumnName("ValorVenda");
            Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            HasOptional(t => t.Empresa)
                .WithMany(t => t.ProdutoEstoques)
                .HasForeignKey(d => d.EmpresaId);
            HasOptional(t => t.Produto)
                .WithMany(t => t.ProdutoEstoques)
                .HasForeignKey(d => d.ProdutoId);

        }
    }
}
