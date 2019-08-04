using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class ProdutoFornecedorEntradaService : ServiceBase<ProdutoFornecedorEntrada>, 
        IProdutoFornecedorEntradaService
    {
        private readonly IProdutoFornecedorEntradaRepository _produtoFornecedorEntradaRepository;

        public ProdutoFornecedorEntradaService(IProdutoFornecedorEntradaRepository produtoFornecedorEntradaRepository):
            base(produtoFornecedorEntradaRepository)
        {
            _produtoFornecedorEntradaRepository = produtoFornecedorEntradaRepository;
        }

        public async Task<IEnumerable<object>> GetAllProdutoFornecedorEntrada(int empresaId)
        {
            return await _produtoFornecedorEntradaRepository.GetAllProdutoFornecedorEntrada(empresaId);
        }
    }


}
