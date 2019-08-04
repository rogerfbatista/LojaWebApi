using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interfaces.Services
{
    public interface IProdutoFornecedorEntradaService : IServiceBase<ProdutoFornecedorEntrada>
    {
        Task<IEnumerable<object>> GetAllProdutoFornecedorEntrada(int empresaId);
    }

  
}
