using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Application.Interfaces
{
    public interface IProdutoFornecedorEntradaAppService : IAppServiceBase<ProdutoFornecedorEntrada>
    {
        Task<IEnumerable<object>> GetAllProdutoFornecedorEntrada(int empresaId);

        Task RemoveLogic(string notafiscal);
    }


}
