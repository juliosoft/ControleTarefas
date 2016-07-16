using Itriad.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Itriad.Infra.Data.EntityMap
{
    /// <summary>
    /// Classe de mapeamento da entidade junto ao banco
    /// </summary>
    public class HistoricoTarefaMap : EntityTypeConfiguration<HistoricoTarefa>
    {
        public HistoricoTarefaMap()
        {
            ToTable("HistoricoTarefa");
            HasKey(c => c.HistoricoTarefaId);

            Property(c => c.DataHoraInicio)
               .IsRequired();

            Property(c => c.EsforcoReal)
               .IsRequired();

            HasRequired(c => c.Tarefa)
                .WithMany().HasForeignKey(c=> c.TarefaId);

            HasRequired(c => c.Responsavel)
                .WithMany().HasForeignKey(c => c.ProfissionalId);
        }
    }
}
