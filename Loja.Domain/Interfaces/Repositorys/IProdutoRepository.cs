using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interfaces.Repositorys
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Task<List<Produto>> GetProduto(string val, int empresaId);
    }
}
    

