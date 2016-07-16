using Itriad.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Itriad.Infra.Data.EntityMap
{
    /// <summary>
    /// Classe de mapeamento da entidade junto ao banco
    /// </summary>
    public class TipoTarefaMap : EntityTypeConfiguration<TipoTarefa>
    {
        public TipoTarefaMap()
        {
            ToTable("TipoTarefa");
            HasKey(c => c.TipoTarefaId);

            Property(c=> c.Descricao).IsRequired();
        }
    }
}
