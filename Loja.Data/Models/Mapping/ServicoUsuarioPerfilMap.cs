
using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;

namespace Loja.Data.Models.Mapping
{
    public class ServicoUsuarioPerfilMap : EntityTypeConfiguration<ServicoUsuarioPerfil>
    {
        public ServicoUsuarioPerfilMap()
        {
            // Primary Key
            HasKey(t => t.ServicoUsuarioPerfilId);

            // Properties
            // Table & Column Mappings
            ToTable("ServicoUsuarioPerfil");
            Property(t => t.ServicoUsuarioPerfilId).HasColumnName("ServicoUsuarioPerfilId");
            Property(t => t.ServicoId).HasColumnName("ServicoId");
            Property(t => t.UsuarioPerfilId).HasColumnName("UsuarioPerfilId");
            Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            HasOptional(t =>  t.Servico)
                .WithMany(t => t.ServicoUsuarioPerfil)
                .HasForeignKey(d => d.ServicoId);

            HasOptional(t => t.UsuarioPerfil).WithMany(t => t.ServicoUsuarioPerfil )
                .HasForeignKey(d => d.UsuarioPerfilId);
        }
    }
}
