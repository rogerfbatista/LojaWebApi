using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class ProdutoClienteSaidaItemService : ServiceBase<ProdutoClienteSaidaItem>, IProdutoClienteSaidaItemService
    {
        private readonly IProdutoClienteSaidaItemRepository _produtoClienteSaidaItemRepository;

        public ProdutoClienteSaidaItemService(IProdutoClienteSaidaItemRepository produtoClienteSaidaItemRepository)
            :base(produtoClienteSaidaItemRepository)
        {
            _produtoClienteSaidaItemRepository = produtoClienteSaidaItemRepository;
        }
    }
}

