using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class ProdutoFormasDePagamentoMap : EntityTypeConfiguration<ProdutoFormasDePagamento>
    {
        public ProdutoFormasDePagamentoMap()
        {
            // Primary Key
            this.HasKey(t => t.ProdutoFormasDePagamentoId);

            // Properties
            this.Property(t => t.NomeFormaPagamento)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("ProdutoFormasDePagamento");
            this.Property(t => t.ProdutoFormasDePagamentoId).HasColumnName("ProdutoFormasDePagamentoId");
            this.Property(t => t.NomeFormaPagamento).HasColumnName("NomeFormaPagamento");
            this.Property(t => t.Ativo).HasColumnName("Ativo");
        }
    }
}
