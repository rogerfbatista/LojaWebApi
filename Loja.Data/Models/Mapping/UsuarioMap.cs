using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;


namespace Loja.Data.Models.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            // Primary Key
            HasKey(t => t.UsuarioId);

            // Properties
            Property(t => t.NomeUsuario)
                .HasMaxLength(50);

            Property(t => t.Email)
                .HasMaxLength(30);

            Property(t => t.Senha)
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("Usuario");
            Property(t => t.UsuarioId).HasColumnName("UsuarioId");
            Property(t => t.UsuarioPerfilId).HasColumnName("UsuarioPerfilId");
            Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            Property(t => t.NomeUsuario).HasColumnName("NomeUsuario");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.Senha).HasColumnName("Senha");
            Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            Property(t => t.ImagemUsuario).HasColumnName("ImagemUsuario");
            Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            HasOptional(t => t.Empresa)
                .WithMany(t => t.Usuarios)
                .HasForeignKey(d => d.EmpresaId);
            HasOptional(t => t.UsuarioPerfil)
                .WithMany(t => t.Usuarios)
                .HasForeignKey(d => d.UsuarioPerfilId);

        }
    }
}
