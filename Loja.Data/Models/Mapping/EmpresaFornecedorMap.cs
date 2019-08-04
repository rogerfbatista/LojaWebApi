using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;

namespace Loja.Data.Models.Mapping
{
    public class EmpresaFornecedorMap : EntityTypeConfiguration<EmpresaFornecedor>
    {
        public EmpresaFornecedorMap()
        {
            // Primary Key
            HasKey(t => t.EmpresaFornecedorId);

            // Properties
            // Table & Column Mappings
            ToTable("EmpresaFornecedor");
            Property(t => t.EmpresaFornecedorId).HasColumnName("EmpresaFornecedorId");
            Property(t => t.FornecedorId).HasColumnName("FornecedorId");
            Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            HasOptional(t => t.Empresa)
                .WithMany(t => t.EmpresaFornecedores)
                .HasForeignKey(d => d.EmpresaId);
            HasOptional(t => t.Fornecedor)
                .WithMany(t => t.EmpresaFornecedores)
                .HasForeignKey(d => d.FornecedorId);

        }
    }
}
