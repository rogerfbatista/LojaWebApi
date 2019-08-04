using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class ProdutoClienteSaidaItemAppService : AppServiceBase<ProdutoClienteSaidaItem>, IProdutoClienteSaidaItemAppService
    {
        private readonly IProdutoClienteSaidaItemService _produtoClienteSaidaItemService;

        public ProdutoClienteSaidaItemAppService(IProdutoClienteSaidaItemService produtoClienteSaidaItemService)
            :base(produtoClienteSaidaItemService)
        {
            _produtoClienteSaidaItemService = produtoClienteSaidaItemService;
        }
    }

}

