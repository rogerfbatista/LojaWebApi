using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
  
    public class ProdutoService :ServiceBase<Produto>,IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository):base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<List<Produto>> GetProduto(string val, int empresaId)
        {
            return await _produtoRepository.GetProduto(val, empresaId);
        }
    }
}
