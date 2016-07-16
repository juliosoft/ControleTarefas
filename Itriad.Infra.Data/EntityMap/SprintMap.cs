using Itriad.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Itriad.Infra.Data.EntityMap
{
    /// <summary>
    /// Classe de mapeamento da entidade junto ao banco
    /// </summary>
    public class SprintMap : EntityTypeConfiguration<Sprint>
    {
        public SprintMap()
        {
            ToTable("Sprint");
            HasKey(c => c.SprintId);

            Property(c => c.Descricao)
           .IsRequired()
            .HasMaxLength(150);


            Property(c => c.InicioPlanejado)
           .IsOptional();

            Property(c => c.InicialReal)
           .IsOptional();

            Property(c => c.FimPlanejado)
          .IsOptional();

            Property(c => c.FimReal)
           .IsOptional();

            HasRequired(c => c.Projeto)
              .WithMany()
              .HasForeignKey(p => p.ProjetoId);
        }
    }
}
