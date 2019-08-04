using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;


namespace Loja.Data.Models.Mapping
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            // Primary Key
            HasKey(t => t.ClienteId);

            // Properties
            Property(t => t.NomeCliente)
                .HasMaxLength(50);

            Property(t => t.CpfCnpj)
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("Cliente");
            Property(t => t.ClienteId).HasColumnName("ClienteId");
            Property(t => t.NomeCliente).HasColumnName("NomeCliente");
            Property(t => t.CpfCnpj).HasColumnName("CpfCnpj");
            Property(t => t.ImagemCliente).HasColumnName("ImagemCliente");
            Property(t => t.Ativo).HasColumnName("Ativo");
        }
    }
}
