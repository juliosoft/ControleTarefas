using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itriad.Infra.CrossCutting.Common.Enum
{
    public enum eSITBACKLOGITEM
    {
        [Description("Novo")]
        NOVO = 0,
        [Description("Aprovado")]
        APROVADO = 1,
        [Description("Iniciado")]
        INICIADO = 3,
        [Description("Cancelado")]
        CANCELADO = 4,
        [Description("Concluído")]
        CONCLUIDO = 5,
        [Description("Suspenso")]
        SUSPENSO = 6
    }
}
