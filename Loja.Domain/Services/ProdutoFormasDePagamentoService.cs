using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class ProdutoFormasDePagamentoService : ServiceBase<ProdutoFormasDePagamento>, IProdutoFormasDePagamentoService
    {
        private readonly IProdutoFormasDePagamentoRepository _produtoFormasDePagamentoRepository;

        public ProdutoFormasDePagamentoService(IProdutoFormasDePagamentoRepository produtoFormasDePagamentoRepository):
            base(produtoFormasDePagamentoRepository)
        {
            _produtoFormasDePagamentoRepository = produtoFormasDePagamentoRepository;
        }
    }



}
