using System.Collections.Generic;
using Itriad.Domain.Entities;
using Itriad.Domain.Interfaces.Repositories;
using Itriad.Domain.Interfaces.Services;
using System.Linq;
using System;

namespace Itriad.Domain.Services
{
    public class ClienteServiceDomain : ServiceBaseDomain<Cliente>, IClienteServiceDomain
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServiceDomain(IClienteRepository clienteRepository)
       : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> Obter(bool querydapper = false)
        {
            return _clienteRepository.Obter(true);
        }
    }
}
