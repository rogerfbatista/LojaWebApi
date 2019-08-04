using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interfaces.Services
{
    public interface IFornecedorService : IServiceBase<Fornecedor>
    {
         Task<List<Fornecedor>> GetAllFornecedor(int id);

        Task<List<Fornecedor>> GetForncedor(string val, int empresaId);
    }
 
}
