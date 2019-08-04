using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;

namespace Loja.Data.Models.Mapping
{
    public class EmpresaContatoMap : EntityTypeConfiguration<EmpresaContato>
    {
        public EmpresaContatoMap()
        {
            // Primary Key
            HasKey(t => t.EmpresaContatoId);

            // Properties
            Property(t => t.Email)
                .HasMaxLength(30);

            Property(t => t.Telefone)
                .HasMaxLength(20);

            // Table & Column Mappings
            ToTable("EmpresaContato");
            Property(t => t.EmpresaContatoId).HasColumnName("EmpresaContatoId");
            Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.Telefone).HasColumnName("Telefone");
            Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            HasOptional(t => t.Empresa)
                .WithMany(t => t.EmpresaContatos)
                .HasForeignKey(d => d.EmpresaId);

        }
    }
}
