using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;


namespace Loja.Data.Models.Mapping
{
    public class MenuTipoMap : EntityTypeConfiguration<MenuTipo>
    {
        public MenuTipoMap()
        {
            // Primary Key
            HasKey(t => t.MenuTipoId);

            // Properties
            Property(t => t.NomeMenuTipo)
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("MenuTipo");
            Property(t => t.MenuTipoId).HasColumnName("MenuTipoId");
            Property(t => t.NomeMenuTipo).HasColumnName("NomeMenuTipo");
        }
    }
}
