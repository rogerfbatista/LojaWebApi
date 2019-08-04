using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;

namespace Loja.Data.Models.Mapping
{
    public class UsuarioPerfilMap : EntityTypeConfiguration<UsuarioPerfil>
    {
        public UsuarioPerfilMap()
        {
            // Primary Key
            HasKey(t => t.UsuarioPerfilId);

            // Properties
            Property(t => t.NomeUsuarioPerfil)
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("UsuarioPerfil");
            Property(t => t.UsuarioPerfilId).HasColumnName("UsuarioPerfilId");
            Property(t => t.NomeUsuarioPerfil).HasColumnName("NomeUsuarioPerfil");
            Property(t => t.ImagemUsuarioPerfil).HasColumnName("ImagemUsuarioPerfil");
            Property(t => t.Ativo).HasColumnName("Ativo");
        }
    }
}
