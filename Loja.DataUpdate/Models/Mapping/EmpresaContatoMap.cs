using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class EmpresaContatoMap : EntityTypeConfiguration<EmpresaContato>
    {
        public EmpresaContatoMap()
        {
            // Primary Key
            this.HasKey(t => t.EmpresaContatoId);

            // Properties
            this.Property(t => t.Email)
                .HasMaxLength(30);

            this.Property(t => t.Telefone)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("EmpresaContato");
            this.Property(t => t.EmpresaContatoId).HasColumnName("EmpresaContatoId");
            this.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            this.HasOptional(t => t.Empresa)
                .WithMany(t => t.EmpresaContatoes)
                .HasForeignKey(d => d.EmpresaId);

        }
    }
}
