using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Application.Interfaces
{
    public interface IProdutoClienteSaidaAppService : IAppServiceBase<ProdutoClienteSaida>
    {
        Task<IEnumerable<object>> GetAllProdutoClienteSaida(int empresaId);
        Task<ProdutoClienteSaida> GetProdutoClienteSaida(int numeroPedido, int empresaId);

        Task<IEnumerable<object>> GetProdutoClienteSaidaPagination(int pageNumber, int pageSize,
            Func<ProdutoClienteSaida, int> orderByFunc, Func<ProdutoClienteSaida, bool> countFunc, int empresaId);
    }

}
