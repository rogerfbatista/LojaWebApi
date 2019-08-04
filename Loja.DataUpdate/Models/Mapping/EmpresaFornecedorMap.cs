using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class EmpresaFornecedorMap : EntityTypeConfiguration<EmpresaFornecedor>
    {
        public EmpresaFornecedorMap()
        {
            // Primary Key
            this.HasKey(t => t.EmpresaFornecedorId);

            // Properties
            // Table & Column Mappings
            this.ToTable("EmpresaFornecedor");
            this.Property(t => t.EmpresaFornecedorId).HasColumnName("EmpresaFornecedorId");
            this.Property(t => t.FornecedorId).HasColumnName("FornecedorId");
            this.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            this.Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            this.HasOptional(t => t.Empresa)
                .WithMany(t => t.EmpresaFornecedors)
                .HasForeignKey(d => d.EmpresaId);
            this.HasOptional(t => t.Fornecedor)
                .WithMany(t => t.EmpresaFornecedors)
                .HasForeignKey(d => d.FornecedorId);

        }
    }
}
