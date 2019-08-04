using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interfaces.Repositorys
{
    public interface IClienteRepository : IRepositoryBase<Cliente> 
    {
        Task<List<Cliente>> GetAllCliente(int empresaId);

        Task<List<Cliente>> GetCliente(string val, int empresaId);
    }
}

