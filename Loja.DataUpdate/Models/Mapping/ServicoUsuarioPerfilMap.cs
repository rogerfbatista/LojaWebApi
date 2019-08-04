using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class ServicoUsuarioPerfilMap : EntityTypeConfiguration<ServicoUsuarioPerfil>
    {
        public ServicoUsuarioPerfilMap()
        {
            // Primary Key
            this.HasKey(t => t.ServicoUsuarioPerfilId);

            // Properties
            // Table & Column Mappings
            this.ToTable("ServicoUsuarioPerfil");
            this.Property(t => t.ServicoUsuarioPerfilId).HasColumnName("ServicoUsuarioPerfilId");
            this.Property(t => t.ServicoId).HasColumnName("ServicoId");
            this.Property(t => t.UsuarioPerfilId).HasColumnName("UsuarioPerfilId");
            this.Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            this.HasOptional(t => t.Servico)
                .WithMany(t => t.ServicoUsuarioPerfils)
                .HasForeignKey(d => d.ServicoId);
            this.HasOptional(t => t.UsuarioPerfil)
                .WithMany(t => t.ServicoUsuarioPerfils)
                .HasForeignKey(d => d.UsuarioPerfilId);

        }
    }
}
