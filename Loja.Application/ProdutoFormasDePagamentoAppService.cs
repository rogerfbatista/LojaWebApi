using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class ProdutoFormasDePagamentoAppService : AppServiceBase<ProdutoFormasDePagamento>, IProdutoFormasDePagamentoAppService
    {
        public ProdutoFormasDePagamentoAppService(IProdutoFormasDePagamentoService produtoFormasDePagamentoService):
            base(produtoFormasDePagamentoService)
        {
        }
    }



}
