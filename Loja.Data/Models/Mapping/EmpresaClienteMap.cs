using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;


namespace Loja.Data.Models.Mapping
{
    public class EmpresaClienteMap : EntityTypeConfiguration<EmpresaCliente>
    {
        public EmpresaClienteMap()
        {
            // Primary Key
            HasKey(t => t.EmpresaClienteId);

            // Properties
            // Table & Column Mappings
            ToTable("EmpresaCliente");
            Property(t => t.EmpresaClienteId).HasColumnName("EmpresaClienteId");
            Property(t => t.ClienteId).HasColumnName("ClienteId");
            Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            HasOptional(t => t.Cliente)
                .WithMany(t => t.EmpresaClientes)
                .HasForeignKey(d => d.ClienteId);
            HasOptional(t => t.Empresa)
                .WithMany(t => t.EmpresaClientes)
                .HasForeignKey(d => d.EmpresaId);

        }
    }
}
