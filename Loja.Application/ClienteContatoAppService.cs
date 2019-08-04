using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class ClienteContatoAppService: AppServiceBase<ClienteContato>,IClienteContatoAppService
    {

        private readonly IClienteContatoService _clienteContatoService;

        public ClienteContatoAppService(IClienteContatoService clienteContatoService)
            : base(clienteContatoService)
            {
            _clienteContatoService = clienteContatoService;
        }
    }
    
}
