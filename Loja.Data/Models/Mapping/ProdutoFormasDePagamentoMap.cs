using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;


namespace Loja.Data.Models.Mapping
{
    public class ProdutoFormasDePagamentoMap : EntityTypeConfiguration<ProdutoFormasDePagamento>
    {
        public ProdutoFormasDePagamentoMap()
        {
            // Primary Key
            HasKey(t => t.ProdutoFormasDePagamentoId);

            // Properties
            Property(t => t.NomeFormaPagamento)
                .HasMaxLength(30);

            // Table & Column Mappings
            ToTable("ProdutoFormasDePagamento");
            Property(t => t.ProdutoFormasDePagamentoId).HasColumnName("ProdutoFormasDePagamentoId");
            Property(t => t.NomeFormaPagamento).HasColumnName("NomeFormaPagamento");
        }
    }
}
