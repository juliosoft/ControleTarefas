using System;

namespace Itriad.Domain.Entities
{
    public class HistoricoTarefa : ClasseBase
    {
        public long HistoricoTarefaId { get; set; }
        public long TarefaId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public double EsforcoReal { get; set; }
        public long ProfissionalId { get; set; }

        public virtual Profissional Responsavel { get; set; }
        public virtual Tarefa Tarefa { get; set; }
    }
}