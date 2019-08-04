using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class ClienteContatoService: ServiceBase<ClienteContato>,IClienteContatoService
    {

        private readonly IClienteContatoRepository _clienteContatoRepository;

        public ClienteContatoService(IClienteContatoRepository clienteContatoRepository):
            base(clienteContatoRepository)
        {
            _clienteContatoRepository = clienteContatoRepository;
        }
    }
    
}
