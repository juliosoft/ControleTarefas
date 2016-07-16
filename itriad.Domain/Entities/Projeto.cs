using Itriad.Infra.CrossCutting.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itriad.Domain.Entities
{
    public class Projeto :ClasseBase
    {
        public long ProjetoId { get; set; }
        public string Nome { get; set; }
        public DateTime? InicioPlanejado { get; set; }
        public DateTime? InicialReal { get; set; }
        public DateTime? FimPlanejado { get; set; }
        public DateTime? FimReal { get; set; }
        public eSITPROJETO SitProjeto { get; set; }

        public long ClienteId { get; set; }
        public long EmpresaId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Empresa Empresa { get; set; }

        public virtual ICollection<BackLogItem> BackLog { get; set; }
        public virtual ICollection<Time> Times { get; set; }
    }
}
