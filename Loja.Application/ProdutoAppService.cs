using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja.Application.Interfaces;
using Loja.Common.Validation;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{

    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService)
            : base(produtoService)
        {
            _produtoService = produtoService;
        }

        public new async Task RemoveLogic(int id, Produto obj)
        {
            var produto = await _produtoService.GetById(id);

            AssertionConcern.AssertArgumentFalse(produto.ProdutoClienteSaidaItems.Any(saida => saida.Ativo == true),
                "Não é possivel Excluir Existem produtos Vendidos");


            AssertionConcern.AssertArgumentFalse(produto.ProdutoEstoques.Any(estoque => estoque.Ativo == true),
                "Não é possivel Excluir Existem produtos no Estoque");


            AssertionConcern.AssertArgumentFalse(produto.ProdutoFornecedorEntradas.Any(estoque => estoque.Ativo == true),
                "Não é possivel Excluir Existem produtos entradas de produto fornecedor");


            produto.Ativo = false;
            await _produtoService.RemoveLogic(id, produto);
        }

        public async Task<List<Produto>> GetProduto(string val, int empresaId)
        {
            return await _produtoService.GetProduto(val, empresaId);
        }
    }
}
