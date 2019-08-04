using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class UsuarioPerfilMenuMap : EntityTypeConfiguration<UsuarioPerfilMenu>
    {
        public UsuarioPerfilMenuMap()
        {
            // Primary Key
            this.HasKey(t => t.UsuarioPerfilMenuId);

            // Properties
            // Table & Column Mappings
            this.ToTable("UsuarioPerfilMenu");
            this.Property(t => t.UsuarioPerfilMenuId).HasColumnName("UsuarioPerfilMenuId");
            this.Property(t => t.MenuId).HasColumnName("MenuId");
            this.Property(t => t.UsuarioPerfilId).HasColumnName("UsuarioPerfilId");
            this.Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            this.HasOptional(t => t.Menu)
                .WithMany(t => t.UsuarioPerfilMenus)
                .HasForeignKey(d => d.MenuId);
            this.HasOptional(t => t.UsuarioPerfil)
                .WithMany(t => t.UsuarioPerfilMenus)
                .HasForeignKey(d => d.UsuarioPerfilId);

        }
    }
}
