using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interfaces.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        Task<List<Cliente>> GetAllCliente(int empresaId);

        Task<List<Cliente>> GetCliente(string val, int empresaId);
    }
}

