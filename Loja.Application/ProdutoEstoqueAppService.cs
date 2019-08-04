using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class ProdutoEstoqueAppService : AppServiceBase<ProdutoEstoque>, IProdutoEstoqueAppService
    {
        private readonly IProdutoEstoqueService _produtoEstoqueService;

        public ProdutoEstoqueAppService(IProdutoEstoqueService produtoEstoqueService)
            : base(produtoEstoqueService)
        {
            _produtoEstoqueService = produtoEstoqueService;
        }


        public async Task<ProdutoEstoque> GetProdutoEstoque(System.Func<ProdutoEstoque, bool> predicate)
        {
            return await _produtoEstoqueService.GetProdutoEstoque(predicate);
        }


        public async Task<List<ProdutoEstoque>> GetProdutoEstoque(string val, int empresaId)
        {
            return await _produtoEstoqueService.GetProdutoEstoque(val, empresaId);
        }


        public async Task<object> GetByIdProdutoEstoque(int id, int empresaId)
        {
            return await _produtoEstoqueService.GetByIdProdutoEstoque(id, empresaId);
        }
    }


}
