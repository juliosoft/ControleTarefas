using Itriad.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Itriad.Infra.Data.EntityMap
{
    /// <summary>
    /// Classe de mapeamento da entidade junto ao banco
    /// </summary>
    public class TimeMap : EntityTypeConfiguration<Time>
    {
        public TimeMap()
        {
            ToTable("Time");
            HasKey(c => c.TimeId);

            Property(c=> c.Nome).IsRequired();

            HasRequired(c => c.Projeto)
              .WithMany()
              .HasForeignKey(p => p.ProjetoId);
        }
    }
}
