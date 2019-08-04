using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class ProdutoTipoService : ServiceBase<ProdutoTipo>, IProdutoTipoService
    {
        private readonly IProdutoTipoRepository _produtoTipoRepository;

        public ProdutoTipoService(IProdutoTipoRepository produtoTipoRepository):base(produtoTipoRepository)
        {
            _produtoTipoRepository = produtoTipoRepository;
        }
    }

 
}
