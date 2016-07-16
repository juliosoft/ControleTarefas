using Itriad.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Itriad.Infra.Data.EntityMap
{
    /// <summary>
    /// Classe de mapeamento da entidade junto ao banco
    /// </summary>
    public class ProfissionalMap : EntityTypeConfiguration<Profissional>
    {
        public ProfissionalMap()
        {
            ToTable("Profissional");
            HasKey(c => c.ProfissionalId);

            Property(c => c.Nome)
               .IsRequired()
               .HasMaxLength(150).HasColumnAnnotation(
           IndexAnnotation.AnnotationName,
           new IndexAnnotation(new IndexAttribute("INDEX_NOME") { IsUnique = true}));

            Property(c => c.Email)
           .IsRequired()
           .HasMaxLength(150).HasColumnAnnotation(
           IndexAnnotation.AnnotationName,
           new IndexAnnotation(new IndexAttribute("INDEX_EMAIL") { IsUnique = true }));

            HasRequired(c => c.Empresa)
            .WithMany().
            HasForeignKey(p => p.EmpresaId);

            HasRequired(c => c.Cargo)
           .WithMany().
           HasForeignKey(p => p.CargoId);

           
        }
    }
}
