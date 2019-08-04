using System.Linq;
using System.Threading.Tasks;
using Loja.Application.Interfaces;
using Loja.Common.Validation;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class ProdutoTipoAppService : AppServiceBase<ProdutoTipo>, IProdutoTipoAppService
    {
        private readonly IProdutoTipoService _produtoTipoService;

        public ProdutoTipoAppService(IProdutoTipoService produtoTipoService)
            : base(produtoTipoService)
        {
            _produtoTipoService = produtoTipoService;
        }

        public new async Task RemoveLogic(int id, ProdutoTipo obj)
        {
            var produtoTipo = await _produtoTipoService.GetById(id);

            AssertionConcern.AssertArgumentFalse(produtoTipo.Produtos.Any(produto => produto.Ativo == true), "Não é possivel Excluir Existem produtos Cadastrados com esse Tipo de Produto");
            produtoTipo.Ativo = false;
            await _produtoTipoService.RemoveLogic(id, produtoTipo);
        }
    }


}
