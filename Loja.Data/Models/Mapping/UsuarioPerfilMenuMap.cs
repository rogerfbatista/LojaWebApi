using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;


namespace Loja.Data.Models.Mapping
{
    public class UsuarioPerfilMenuMap : EntityTypeConfiguration<UsuarioPerfilMenu>
    {
        public UsuarioPerfilMenuMap()
        {
            // Primary Key
            HasKey(t => t.UsuarioPerfilMenuId);

            // Properties
            // Table & Column Mappings
            ToTable("UsuarioPerfilMenu");
            Property(t => t.UsuarioPerfilMenuId).HasColumnName("UsuarioPerfilMenuId");
            Property(t => t.MenuId).HasColumnName("MenuId");
            Property(t => t.UsuarioPerfilId).HasColumnName("UsuarioPerfilId");

            // Relationships
            HasOptional(t => t.Menu)
                .WithMany(t => t.UsuarioPerfilMenus)
                .HasForeignKey(d => d.MenuId);
            HasOptional(t => t.UsuarioPerfil)
                .WithMany(t => t.UsuarioPerfilMenus)
                .HasForeignKey(d => d.UsuarioPerfilId);

        }
    }
}
