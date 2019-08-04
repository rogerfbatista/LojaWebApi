using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Application.Interfaces
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        Task<List<Produto>> GetProduto(string val, int empresaId);
    }
}
    

