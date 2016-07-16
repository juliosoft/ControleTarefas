using Itriad.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Itriad.Application.Interfaces
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        IEnumerable<Cliente> Obter();
    }
}
