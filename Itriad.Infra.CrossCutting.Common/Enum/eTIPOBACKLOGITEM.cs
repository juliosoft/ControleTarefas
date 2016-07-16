using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itriad.Infra.CrossCutting.Common.Enum
{
    public enum eTIPOBACKLOGITEM
    {
        [Description("Back Log item")]
        BACKLOGITEM = 0,
        [Description("Bug")]
        BUG = 1
    }
}
