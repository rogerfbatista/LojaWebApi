using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Application.Interfaces
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        Task<List<Cliente>> GetAllCliente(int empresaId);
        Task<List<Cliente>> GetCliente(string val, int empresaId);
    }
}

