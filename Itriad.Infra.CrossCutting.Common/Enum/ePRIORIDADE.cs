using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itriad.Infra.CrossCutting.Common.Enum
{
    public enum ePRIORIDADE
    {
        [Description("Baixa")]
        BAIXA = 0,
        [Description("Média")]
        MEDIA = 1,
        [Description("Alta")]
        ALTA = 2
    }
}
