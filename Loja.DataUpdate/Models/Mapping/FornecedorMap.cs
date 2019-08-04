using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class FornecedorMap : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorMap()
        {
            // Primary Key
            this.HasKey(t => t.FornecedorId);

            // Properties
            this.Property(t => t.NomeFornecedor)
                .HasMaxLength(50);

            this.Property(t => t.Cnpj)
                .HasMaxLength(20);

            this.Property(t => t.InscricaoEstadual)
                .HasMaxLength(20);

            this.Property(t => t.Endereco)
                .HasMaxLength(50);

            this.Property(t => t.Numero)
                .HasMaxLength(10);

            this.Property(t => t.Estado)
                .HasMaxLength(30);

            this.Property(t => t.Cidade)
                .HasMaxLength(30);

            this.Property(t => t.Contato)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Fornecedor");
            this.Property(t => t.FornecedorId).HasColumnName("FornecedorId");
            this.Property(t => t.NomeFornecedor).HasColumnName("NomeFornecedor");
            this.Property(t => t.Cnpj).HasColumnName("Cnpj");
            this.Property(t => t.InscricaoEstadual).HasColumnName("InscricaoEstadual");
            this.Property(t => t.Endereco).HasColumnName("Endereco");
            this.Property(t => t.Numero).HasColumnName("Numero");
            this.Property(t => t.Estado).HasColumnName("Estado");
            this.Property(t => t.Cidade).HasColumnName("Cidade");
            this.Property(t => t.ImagemCliente).HasColumnName("ImagemCliente");
            this.Property(t => t.Ativo).HasColumnName("Ativo");
            this.Property(t => t.Contato).HasColumnName("Contato");
        }
    }
}
