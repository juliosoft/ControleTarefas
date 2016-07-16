using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itriad.Infra.CrossCutting.Common.Enum
{
    public enum eOPERACAO
    {
        [Description("Criar")]
        CRIAR,
        [Description("Inserir")]
        INSERIR,
        [Description("Atualizar")]
        ATUALIZAR,
        [Description("Deletar")]
        DELETAR,
        [Description("Inativar")]
        INATIVAR
    }
}
