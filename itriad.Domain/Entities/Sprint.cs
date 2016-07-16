using Itriad.Infra.CrossCutting.Common.Enum;
using System;
using System.Collections.Generic;

namespace Itriad.Domain.Entities
{
    public class Sprint : ClasseBase
    {
        public long SprintId { get; set; }
        public string Descricao { get; set; }

        public DateTime? InicioPlanejado { get; set; }
        public DateTime? InicialReal { get; set; }
        public DateTime? FimPlanejado { get; set; }
        public DateTime? FimReal { get; set; }
        public long ProjetoId { get; set; }
        public virtual Projeto Projeto { get; set; }
        public virtual ICollection<BackLogItem> BackLogItems { get; set; }
    }
}