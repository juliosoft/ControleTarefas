using Itriad.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Itriad.Infra.Data.EntityMap
{
    /// <summary>
    /// Classe de mapeamento da entidade junto ao banco
    /// </summary>
    public class ProjetoMap : EntityTypeConfiguration<Projeto>
    {
        public ProjetoMap()
        {
            ToTable("Projeto");
            HasKey(c => c.ProjetoId);

            Property(c => c.Nome)
               .IsRequired()
               .HasMaxLength(150).HasColumnAnnotation(
           IndexAnnotation.AnnotationName,
           new IndexAnnotation(new IndexAttribute("INDEX_NOME") { IsUnique = true}));

            Property(c => c.InicioPlanejado)
               .IsOptional();

            Property(c => c.InicialReal)
               .IsOptional();

            Property(c => c.FimPlanejado)
               .IsOptional();

            Property(c => c.FimReal)
               .IsOptional();

            HasRequired(c => c.Cliente)
              .WithMany().
              HasForeignKey(p => p.ClienteId);
        }
    }
}
