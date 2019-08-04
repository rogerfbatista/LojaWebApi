using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        Task<List<Produto>> GetProduto(string val, int empresaId);
    }
}
    

