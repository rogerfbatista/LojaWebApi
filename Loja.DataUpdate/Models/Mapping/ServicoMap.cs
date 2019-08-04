using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Loja.DataUpdate.Models.Mapping
{
    public class ServicoMap : EntityTypeConfiguration<Servico>
    {
        public ServicoMap()
        {
            // Primary Key
            this.HasKey(t => t.ServicoId);

            // Properties
            this.Property(t => t.NomeServico)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Servico");
            this.Property(t => t.ServicoId).HasColumnName("ServicoId");
            this.Property(t => t.NomeServico).HasColumnName("NomeServico");
            this.Property(t => t.Ativo).HasColumnName("Ativo");
        }
    }
}
