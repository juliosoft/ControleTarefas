using Itriad.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Itriad.Infra.Data.EntityMap
{
    /// <summary>
    /// Classe de mapeamento da entidade junto ao banco
    /// </summary>
    public class TarefaMap : EntityTypeConfiguration<Tarefa>
    {
        public TarefaMap()
        {
            ToTable("Tarefa");
            HasKey(c => c.TarefaId);

            Property(c => c.Titulo)
               .IsRequired()
               .HasMaxLength(150);

            Property(c => c.Descricao)
               .IsRequired()
               .HasMaxLength(4000);

            HasRequired(c => c.TipoTarefa)
                .WithMany().HasForeignKey(c=> c.TipoTarefaId);

            HasRequired(c => c.BackLogItem)
                .WithMany().HasForeignKey(c => c.BackLogItemId);

            HasOptional(c => c.Responsavel)
                .WithMany().HasForeignKey(c => c.ProfissionalId);

            Property(c => c.EsforcoPrevisto)
            .IsOptional();

            Property(c => c.EsforcoReal)
           .IsOptional();

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
