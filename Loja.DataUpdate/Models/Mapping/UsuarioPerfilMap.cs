using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class UsuarioPerfilMap : EntityTypeConfiguration<UsuarioPerfil>
    {
        public UsuarioPerfilMap()
        {
            // Primary Key
            this.HasKey(t => t.UsuarioPerfilId);

            // Properties
            this.Property(t => t.NomeUsuarioPerfil)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UsuarioPerfil");
            this.Property(t => t.UsuarioPerfilId).HasColumnName("UsuarioPerfilId");
            this.Property(t => t.NomeUsuarioPerfil).HasColumnName("NomeUsuarioPerfil");
            this.Property(t => t.ImagemUsuarioPerfil).HasColumnName("ImagemUsuarioPerfil");
            this.Property(t => t.Ativo).HasColumnName("Ativo");
        }
    }
}
