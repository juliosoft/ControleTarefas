using Itriad.Domain.Entities;
using Itriad.Infra.CrossCutting.Common.Enum;
using System;

namespace Itriad.Domain.Entities
{
    public class BackLogItem
    {
        public long BackLogItemId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string CriterioAceite { get; set; }
        public ePRIORIDADE Prioridade { get; set; }
        public eTIPOBACKLOGITEM Tipo { get; set; }
        public eSITBACKLOGITEM Status { get; set; }
        public double EsforcoPrevisto { get; set; }
        public double EsforcoReal { get; set; }
        public long ProjetoId { get; set; }
        public long? SprintId { get; set; }

        public DateTime? InicioPlanejado { get; set; }
        public DateTime? InicioReal { get; set; }
        public DateTime? FimPlanejado { get; set; }
        public DateTime? FimReal { get; set; }

        public virtual Projeto Projeto { get; set; }
        public virtual Sprint Sprint { get; set; }
    }
}