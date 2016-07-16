using System.Web;

namespace Itriad.Infra.Data.Context
{
    /// <summary>
    /// Controla o ciclo de vida de um contexto, mantendo sempre uma unica conexão
    /// </summary>
    public class ContextManager
    {
        public const string ContextKey = "ContextManager.Context";

        public ItriadContexto Contexto
        {
            get
            { if (HttpContext.Current.Items[ContextKey] == null)
                 HttpContext.Current.Items[ContextKey] = new ItriadContexto();
                 return (ItriadContexto)HttpContext.Current.Items[ContextKey];
            }
        }
    }
}
