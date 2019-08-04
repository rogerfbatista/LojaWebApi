using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class MenuTipoMap : EntityTypeConfiguration<MenuTipo>
    {
        public MenuTipoMap()
        {
            // Primary Key
            this.HasKey(t => t.MenuTipoId);

            // Properties
            this.Property(t => t.NomeMenuTipo)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MenuTipo");
            this.Property(t => t.MenuTipoId).HasColumnName("MenuTipoId");
            this.Property(t => t.NomeMenuTipo).HasColumnName("NomeMenuTipo");
            this.Property(t => t.Ativo).HasColumnName("Ativo");
        }
    }
}
