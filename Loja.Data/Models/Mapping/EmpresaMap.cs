using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;


namespace Loja.Data.Models.Mapping
{
    public class EmpresaMap : EntityTypeConfiguration<Empresa>
    {
        public EmpresaMap()
        {
            // Primary Key
            HasKey(t => t.EmpresaId);

            // Properties
            Property(t => t.NomeEmpresa)
                .HasMaxLength(50);

            Property(t => t.NomeFantasia)
                .HasMaxLength(50);

            Property(t => t.Contato)
                .HasMaxLength(30);

            Property(t => t.InscricaoEstadual)
                .HasMaxLength(20);

            Property(t => t.Cnpj)
                .HasMaxLength(20);

            Property(t => t.Endereco)
                .HasMaxLength(50);

            Property(t => t.Numero)
                .HasMaxLength(10);

            Property(t => t.Estado)
                .HasMaxLength(30);

            Property(t => t.Cidade)
                .HasMaxLength(30);

            // Table & Column Mappings
            ToTable("Empresa");
            Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            Property(t => t.NomeEmpresa).HasColumnName("NomeEmpresa");
            Property(t => t.NomeFantasia).HasColumnName("NomeFantasia");
            Property(t => t.Contato).HasColumnName("Contato");
            Property(t => t.InscricaoEstadual).HasColumnName("InscricaoEstadual");
            Property(t => t.Cnpj).HasColumnName("Cnpj");
            Property(t => t.Endereco).HasColumnName("Endereco");
            Property(t => t.Numero).HasColumnName("Numero");
            Property(t => t.Estado).HasColumnName("Estado");
            Property(t => t.Cidade).HasColumnName("Cidade");
            Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            Property(t => t.EmpresaImagem).HasColumnName("EmpresaImagem");
            Property(t => t.Ativo).HasColumnName("Ativo");
        }
    }
}
