using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;

namespace Loja.Data.Models.Mapping
{
    public class ProdutoClienteSaidaMap : EntityTypeConfiguration<ProdutoClienteSaida>
    {
        public ProdutoClienteSaidaMap()
        {
            // Primary Key
            this.HasKey(t => t.ProdutoClienteSaidaId);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProdutoClienteSaida");
            this.Property(t => t.ProdutoClienteSaidaId).HasColumnName("ProdutoClienteSaidaId");
            this.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            this.Property(t => t.ClienteId).HasColumnName("ClienteId");
            this.Property(t => t.ProdutoFormasDePagamentoId).HasColumnName("ProdutoFormasDePagamentoId");
            this.Property(t => t.ValorTotal).HasColumnName("ValorTotal");
            this.Property(t => t.DataVenda).HasColumnName("DataVenda");
            this.Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships

            this.HasOptional(t => t.Cliente)
               .WithMany(t => t.ProdutoClienteSaidas)
               .HasForeignKey(d => d.ClienteId);

            this.HasOptional(t => t.Empresa)
                .WithMany(t => t.ProdutoClienteSaidas)
                .HasForeignKey(d => d.EmpresaId);
            this.HasOptional(t => t.ProdutoFormasDePagamento)
                .WithMany(t => t.ProdutoClienteSaidas)
                .HasForeignKey(d => d.ProdutoFormasDePagamentoId);

        }
    }
}
