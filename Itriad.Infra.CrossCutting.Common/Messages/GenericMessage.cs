using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itriad.Infra.CrossCutting.Common.Messages
{
    public static class GenericMessage
    {
        public static string Success()
        {
            return "Operação realizada com sucesso.";
        }

        public static string Error()
        {
            return "Não foi possível realizar a operação desejada, contacte o administrador.";
        }
    }
}
