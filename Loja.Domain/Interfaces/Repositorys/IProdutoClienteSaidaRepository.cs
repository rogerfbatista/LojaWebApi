using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interfaces.Repositorys
{
    public interface IProdutoClienteSaidaRepository : IRepositoryBase<ProdutoClienteSaida>
    {
        Task<IEnumerable<object>> GetAllProdutoClienteSaida(int empresaId);
        Task<ProdutoClienteSaida> GetProdutoClienteSaida(int numeroPedido, int empresaId);

        Task<IEnumerable<object>> GetProdutoClienteSaidaPagination(int pageNumber, int pageSize,
            System.Func<ProdutoClienteSaida, int> orderByFunc, System.Func<ProdutoClienteSaida, bool> countFunc,
             int empresaId);
    }
   
}
