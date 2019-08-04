using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class EmpresaClienteMap : EntityTypeConfiguration<EmpresaCliente>
    {
        public EmpresaClienteMap()
        {
            // Primary Key
            this.HasKey(t => t.EmpresaClienteId);

            // Properties
            // Table & Column Mappings
            this.ToTable("EmpresaCliente");
            this.Property(t => t.EmpresaClienteId).HasColumnName("EmpresaClienteId");
            this.Property(t => t.ClienteId).HasColumnName("ClienteId");
            this.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            this.Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            this.HasOptional(t => t.Cliente)
                .WithMany(t => t.EmpresaClientes)
                .HasForeignKey(d => d.ClienteId);
            this.HasOptional(t => t.Empresa)
                .WithMany(t => t.EmpresaClientes)
                .HasForeignKey(d => d.EmpresaId);

        }
    }
}
