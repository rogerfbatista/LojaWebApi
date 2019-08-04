using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;

namespace Loja.Data.Models.Mapping
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            // Primary Key
            HasKey(t => t.MenuId);

            // Properties
            Property(t => t.NomeMenu)
                .HasMaxLength(50);

            Property(t => t.Link)
                .HasMaxLength(500);

            // Table & Column Mappings
            ToTable("Menu");
            Property(t => t.MenuId).HasColumnName("MenuId");
            Property(t => t.MenuTipoId).HasColumnName("MenuTipoId");
            Property(t => t.MenuIdFk).HasColumnName("MenuIdFk");
            Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            Property(t => t.NomeMenu).HasColumnName("NomeMenu");
            Property(t => t.Link).HasColumnName("Link");
            Property(t => t.Ordem).HasColumnName("Ordem");
            Property(t => t.ImagemMenu).HasColumnName("ImagemMenu");
            Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            HasOptional(t => t.Empresa)
                .WithMany(t => t.Menus)
                .HasForeignKey(d => d.EmpresaId);
            HasOptional(t => t.MenuClassMenu)
                .WithMany(t => t.MenuCollection)
                .HasForeignKey(d => d.MenuIdFk);
            HasOptional(t => t.MenuTipo)
                .WithMany(t => t.Menu)
                .HasForeignKey(d => d.MenuTipoId);

        }
    }
}
