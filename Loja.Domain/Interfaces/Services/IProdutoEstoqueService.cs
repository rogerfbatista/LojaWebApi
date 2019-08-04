
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interfaces.Services
{
    public interface IProdutoEstoqueService  : IServiceBase<ProdutoEstoque>
    {
        Task<ProdutoEstoque> GetProdutoEstoque(Func<ProdutoEstoque, bool> predicate);
        Task<List<ProdutoEstoque>> GetProdutoEstoque(string val, int empresaId);
        Task<object> GetByIdProdutoEstoque(int id, int empresaId);
    }
    
}
