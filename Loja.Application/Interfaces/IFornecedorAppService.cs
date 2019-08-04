using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Application.Interfaces
{
    public interface IFornecedorAppService : IAppServiceBase<Fornecedor>
    {
        Task<List<Fornecedor>> GetAllFornecedor(int empresaId);

        Task<List<Fornecedor>> GetForncedor(string val, int empresaId);
    }
 
}
