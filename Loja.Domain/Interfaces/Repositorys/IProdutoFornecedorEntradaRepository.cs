using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interfaces.Repositorys
{
    public interface IProdutoFornecedorEntradaRepository : IRepositoryBase<ProdutoFornecedorEntrada>
    {
        Task<IEnumerable<object>> GetAllProdutoFornecedorEntrada(int empresaId);
    }

  
}
