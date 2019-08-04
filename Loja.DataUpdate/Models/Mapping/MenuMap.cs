using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            // Primary Key
            this.HasKey(t => t.MenuId);

            // Properties
            this.Property(t => t.NomeMenu)
                .HasMaxLength(50);

            this.Property(t => t.Link)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Menu");
            this.Property(t => t.MenuId).HasColumnName("MenuId");
            this.Property(t => t.MenuTipoId).HasColumnName("MenuTipoId");
            this.Property(t => t.MenuIdFk).HasColumnName("MenuIdFk");
            this.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            this.Property(t => t.NomeMenu).HasColumnName("NomeMenu");
            this.Property(t => t.Link).HasColumnName("Link");
            this.Property(t => t.Ordem).HasColumnName("Ordem");
            this.Property(t => t.ImagemMenu).HasColumnName("ImagemMenu");
            this.Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            this.HasOptional(t => t.Empresa)
                .WithMany(t => t.Menus)
                .HasForeignKey(d => d.EmpresaId);
            this.HasOptional(t => t.Menu2)
                .WithMany(t => t.Menu1)
                .HasForeignKey(d => d.MenuIdFk);
            this.HasOptional(t => t.MenuTipo)
                .WithMany(t => t.Menus)
                .HasForeignKey(d => d.MenuTipoId);

        }
    }
}
