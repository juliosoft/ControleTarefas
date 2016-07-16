using Itriad.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Itriad.Infra.Data.EntityMap
{
    /// <summary>
    /// Classe de mapeamento da entidade junto ao banco
    /// </summary>
    public class BackLogItemMap : EntityTypeConfiguration<BackLogItem>
    {
        public BackLogItemMap()
        {
            ToTable("BackLogItem");
            HasKey(c => c.BackLogItemId);

            Property(c => c.Titulo)
         .IsRequired()
         .HasMaxLength(150);

            Property(c => c.Descricao)
         .IsRequired()
         .HasMaxLength(4000);

            Property(c => c.CriterioAceite)
            .IsOptional()
            .HasMaxLength(4000);

            HasRequired(c => c.Projeto)
              .WithMany().
              HasForeignKey(p => p.ProjetoId);

            HasOptional(c => c.Sprint)
              .WithMany().
              HasForeignKey(p => p.SprintId);

            Property(c => c.InicioPlanejado)
            .IsOptional();

            Property(c => c.FimPlanejado)
            .IsOptional();

            Property(c => c.InicioReal)
            .IsOptional();

            Property(c => c.FimReal)
            .IsOptional();
        }
    }
}
