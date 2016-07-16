using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itriad.Infra.CrossCutting.Common.Enum
{
    public enum eSITPROJETO : int
    {
        [Description("Planejado")]
        PLANEJADO = 1,
        [Description("Em andamento")]
        EMANDAMENTO = 2,
        [Description("Finalizado")]
        FINALIZADO = 3,
        [Description("Suspenso")]
        SUSPENSO = 4,
        [Description("Cancelado")]
        CANCELADO = 5
    }
}
