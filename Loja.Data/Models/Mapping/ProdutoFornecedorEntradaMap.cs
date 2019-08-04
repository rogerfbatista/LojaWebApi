using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;


namespace Loja.Data.Models.Mapping
{
    public class ProdutoFornecedorEntradaMap : EntityTypeConfiguration<ProdutoFornecedorEntrada>
    {
        public ProdutoFornecedorEntradaMap()
        {
            // Primary Key
            HasKey(t => t.ProdutoEntradaId);

            // Properties
            // Table & Column Mappings
            ToTable("ProdutoFornecedorEntrada");
            Property(t => t.ProdutoEntradaId).HasColumnName("ProdutoEntradaId");
            Property(t => t.ProdutoId).HasColumnName("ProdutoId");
            Property(t => t.FornecedorId).HasColumnName("FornecedorId");
            Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            Property(t => t.NotaFiscalId).HasColumnName("NotaFiscalId").HasMaxLength(10).HasColumnType("VARCHAR");
            Property(t => t.QuantidadeEntrada).HasColumnName("QuantidadeEntrada");
            Property(t => t.ValorUnitario).HasColumnName("ValorUnitario");
            Property(t => t.DataEntrada).HasColumnName("DataEntrada");
            Property(t => t.DataEmissao).HasColumnName("DataEmissao");
            Property(t => t.DataVencimento).HasColumnName("DataVencimento");
            Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            HasOptional(t => t.Empresa)
                .WithMany(t => t.ProdutoFornecedorEntradas)
                .HasForeignKey(d => d.EmpresaId);
            HasOptional(t => t.Fornecedor)
                .WithMany(t => t.ProdutoFornecedorEntradas)
                .HasForeignKey(d => d.FornecedorId);
            HasOptional(t => t.Produto)
                .WithMany(t => t.ProdutoFornecedorEntradas)
                .HasForeignKey(d => d.ProdutoId);

        }
    }
}
