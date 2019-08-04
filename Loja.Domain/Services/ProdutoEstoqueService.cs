using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class ProdutoEstoqueService : ServiceBase<ProdutoEstoque>, IProdutoEstoqueService
    {
        private readonly IProdutoEstoqueRepository _produtoEstoqueRepository;

        public ProdutoEstoqueService(IProdutoEstoqueRepository produtoEstoqueRepository) :
            base(produtoEstoqueRepository)
        {
            _produtoEstoqueRepository = produtoEstoqueRepository;
        }

        public async Task<ProdutoEstoque> GetProdutoEstoque(System.Func<ProdutoEstoque, bool> predicate)
        {
            return await _produtoEstoqueRepository.GetProdutoEstoque(predicate);
        }


        public async Task<System.Collections.Generic.List<ProdutoEstoque>> GetProdutoEstoque(string val, int empresaId)
        {
            return await _produtoEstoqueRepository.GetProdutoEstoque(val, empresaId);
        }


        public async Task<object> GetByIdProdutoEstoque(int id, int empresaId)
        {
            return await _produtoEstoqueRepository.GetByIdProdutoEstoque(id, empresaId);
        }
    }


}
