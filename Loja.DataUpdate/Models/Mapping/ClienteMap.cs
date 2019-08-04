using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            // Primary Key
            this.HasKey(t => t.ClienteId);

            // Properties
            this.Property(t => t.NomeCliente)
                .HasMaxLength(50);

            this.Property(t => t.CpfCnpj)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Cliente");
            this.Property(t => t.ClienteId).HasColumnName("ClienteId");
            this.Property(t => t.NomeCliente).HasColumnName("NomeCliente");
            this.Property(t => t.CpfCnpj).HasColumnName("CpfCnpj");
            this.Property(t => t.ImagemCliente).HasColumnName("ImagemCliente");
            this.Property(t => t.Ativo).HasColumnName("Ativo");
        }
    }
}
