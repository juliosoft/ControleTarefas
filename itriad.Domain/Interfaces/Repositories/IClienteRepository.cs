using Itriad.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Itriad.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface do Repositório de clientes
    /// </summary>
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        IEnumerable<Cliente> Obter(bool dapper = false);
    }
}
