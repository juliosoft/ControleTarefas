using Itriad.Application.Interfaces;
using Itriad.Domain.Entities;
using Itriad.Domain.Interfaces.Services;
using System.Collections.Generic;
using System;

namespace Itriad.Application
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteServiceDomain _clienteService;

        public ClienteAppService(IClienteServiceDomain clienteService) :base (clienteService)
        {
            _clienteService = clienteService;
        }

        public IEnumerable<Cliente> Obter()
        {
            return _clienteService.Obter(true);
        }
    }
}
