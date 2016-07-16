using Itriad.Domain.Entities;
using Itriad.Infra.CrossCutting.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itriad.Domain.Entities
{
    public class Tarefa : ClasseBase
    {
        public long TarefaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public ePRIORIDADE Prioridade { get; set; }
        public long TipoTarefaId { get; set; }
        public long? ProfissionalId { get; set; }
        public long BackLogItemId { get; set; }
        public double? EsforcoPrevisto { get; set; }
        public double? EsforcoReal { get; set; }

        public DateTime? InicioPlanejado { get; set; }
        public DateTime? InicioReal { get; set; }
        public DateTime? FimPlanejado { get; set; }
        public DateTime? FimReal { get; set; }

        public virtual BackLogItem BackLogItem { get; set; }
        public virtual TipoTarefa TipoTarefa { get; set; }
        public virtual Profissional Responsavel { get; set; }
        public ICollection<HistoricoTarefa> HistoricoTarefa { get; set; }
    }
}
