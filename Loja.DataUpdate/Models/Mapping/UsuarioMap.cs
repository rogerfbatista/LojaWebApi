using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.UsuarioId);

            // Properties
            this.Property(t => t.NomeUsuario)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(30);

            this.Property(t => t.Senha)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Usuario");
            this.Property(t => t.UsuarioId).HasColumnName("UsuarioId");
            this.Property(t => t.UsuarioPerfilId).HasColumnName("UsuarioPerfilId");
            this.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            this.Property(t => t.NomeUsuario).HasColumnName("NomeUsuario");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Senha).HasColumnName("Senha");
            this.Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            this.Property(t => t.ImagemUsuario).HasColumnName("ImagemUsuario");
            this.Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            this.HasOptional(t => t.Empresa)
                .WithMany(t => t.Usuarios)
                .HasForeignKey(d => d.EmpresaId);
            this.HasOptional(t => t.UsuarioPerfil)
                .WithMany(t => t.Usuarios)
                .HasForeignKey(d => d.UsuarioPerfilId);

        }
    }
}
