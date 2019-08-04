using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class EmpresaMap : EntityTypeConfiguration<Empresa>
    {
        public EmpresaMap()
        {
            // Primary Key
            this.HasKey(t => t.EmpresaId);

            // Properties
            this.Property(t => t.NomeEmpresa)
                .HasMaxLength(50);

            this.Property(t => t.NomeFantasia)
                .HasMaxLength(50);

            this.Property(t => t.Contato)
                .HasMaxLength(30);

            this.Property(t => t.InscricaoEstadual)
                .HasMaxLength(20);

            this.Property(t => t.Cnpj)
                .HasMaxLength(20);

            this.Property(t => t.Endereco)
                .HasMaxLength(50);

            this.Property(t => t.Numero)
                .HasMaxLength(10);

            this.Property(t => t.Estado)
                .HasMaxLength(30);

            this.Property(t => t.Cidade)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("Empresa");
            this.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            this.Property(t => t.NomeEmpresa).HasColumnName("NomeEmpresa");
            this.Property(t => t.NomeFantasia).HasColumnName("NomeFantasia");
            this.Property(t => t.Contato).HasColumnName("Contato");
            this.Property(t => t.InscricaoEstadual).HasColumnName("InscricaoEstadual");
            this.Property(t => t.Cnpj).HasColumnName("Cnpj");
            this.Property(t => t.Endereco).HasColumnName("Endereco");
            this.Property(t => t.Numero).HasColumnName("Numero");
            this.Property(t => t.Estado).HasColumnName("Estado");
            this.Property(t => t.Cidade).HasColumnName("Cidade");
            this.Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            this.Property(t => t.EmpresaImagem).HasColumnName("EmpresaImagem");
            this.Property(t => t.Ativo).HasColumnName("Ativo");
        }
    }
}
