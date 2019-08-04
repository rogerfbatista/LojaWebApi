using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Cliente>> GetAllCliente(int empresaId)
        {
            return await _clienteRepository.GetAllCliente(empresaId);
        }


        public async Task<List<Cliente>> GetCliente(string val, int empresaId)
        {
            return await _clienteRepository.GetCliente(val, empresaId);
        }
    }
}

