using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;


namespace Loja.Data.Models.Mapping
{
    public class FornecedorMap : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorMap()
        {
            // Primary Key
            HasKey(t => t.FornecedorId);

            // Properties
            Property(t => t.NomeFornecedor)
                .HasMaxLength(50);

            // Properties
            Property(t => t.Contato)
                .HasMaxLength(50);

            Property(t => t.Cnpj)
                .HasMaxLength(20);

            Property(t => t.InscricaoEstadual)
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
            ToTable("Fornecedor");
            Property(t => t.FornecedorId).HasColumnName("FornecedorId");
            Property(t => t.NomeFornecedor).HasColumnName("NomeFornecedor");
            Property(t => t.Contato).HasColumnName("Contato").HasColumnType("VARCHAR");
            Property(t => t.Cnpj).HasColumnName("Cnpj");
            Property(t => t.InscricaoEstadual).HasColumnName("InscricaoEstadual");
            Property(t => t.Endereco).HasColumnName("Endereco");
            Property(t => t.Numero).HasColumnName("Numero");
            Property(t => t.Estado).HasColumnName("Estado");
            Property(t => t.Cidade).HasColumnName("Cidade");
            Property(t => t.ImagemCliente).HasColumnName("ImagemCliente");
            Property(t => t.Ativo).HasColumnName("Ativo");
        }
    }
}
