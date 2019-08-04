
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Loja.Domain.Entities;
using System.Data.Entity.Infrastructure.Annotations;
namespace Loja.Data.Models.Mapping
{

    public class ServicoMap : EntityTypeConfiguration<Servico>
    {

        public ServicoMap()
        {

            // Primary Key
            HasKey(t => t.ServicoId);

            // Properties
            Property(t => t.NomeServico)
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("Servico");
            Property(t => t.ServicoId).HasColumnName("ServicoId");
            Property(t => t.NomeServico)
                .HasColumnName("NomeServico")
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute()));
            
            Property(t => t.Ativo).HasColumnName("Ativo");
        }
    }
}
