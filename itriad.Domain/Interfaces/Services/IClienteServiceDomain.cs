using Itriad.Domain.Entities;

using System.Collections.Generic;

namespace Itriad.Domain.Interfaces.Services
{
    public interface IClienteServiceDomain : IServiceBaseDomain<Cliente>
    {
        IEnumerable<Cliente> Obter(bool querydapper = false);
    }
}
