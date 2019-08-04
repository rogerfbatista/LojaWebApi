using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class ProdutoFornecedorEntradaMap : EntityTypeConfiguration<ProdutoFornecedorEntrada>
    {
        public ProdutoFornecedorEntradaMap()
        {
            // Primary Key
            this.HasKey(t => t.ProdutoEntradaId);

            // Properties
            this.Property(t => t.NotaFiscalId)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("ProdutoFornecedorEntrada");
            this.Property(t => t.ProdutoEntradaId).HasColumnName("ProdutoEntradaId");
            this.Property(t => t.ProdutoId).HasColumnName("ProdutoId");
            this.Property(t => t.FornecedorId).HasColumnName("FornecedorId");
            this.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            this.Property(t => t.NotaFiscalId).HasColumnName("NotaFiscalId");
            this.Property(t => t.QuantidadeEntrada).HasColumnName("QuantidadeEntrada");
            this.Property(t => t.ValorUnitario).HasColumnName("ValorUnitario");
            this.Property(t => t.DataEntrada).HasColumnName("DataEntrada");
            this.Property(t => t.DataEmissao).HasColumnName("DataEmissao");
            this.Property(t => t.DataVencimento).HasColumnName("DataVencimento");
            this.Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            this.HasOptional(t => t.Empresa)
                .WithMany(t => t.ProdutoFornecedorEntradas)
                .HasForeignKey(d => d.EmpresaId);
            this.HasOptional(t => t.Fornecedor)
                .WithMany(t => t.ProdutoFornecedorEntradas)
                .HasForeignKey(d => d.FornecedorId);
            this.HasOptional(t => t.Produto)
                .WithMany(t => t.ProdutoFornecedorEntradas)
                .HasForeignKey(d => d.ProdutoId);

        }
    }
}
