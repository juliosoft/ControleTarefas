using Itriad.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Itriad.Infra.Data.EntityMap
{
    /// <summary>
    /// Classe de mapeamento da entidade junto ao banco
    /// </summary>
    public class CargoMap : EntityTypeConfiguration<Cargo>
    {
        public CargoMap()
        {
            ToTable("Cargo");
            HasKey(c => c.CargoId);

            Property(c => c.Descricao)
               .IsRequired()
               .HasMaxLength(150).HasColumnAnnotation(
           IndexAnnotation.AnnotationName,
           new IndexAnnotation(new IndexAttribute("INDEX_DESCRICAO")));
        }
    }
}
