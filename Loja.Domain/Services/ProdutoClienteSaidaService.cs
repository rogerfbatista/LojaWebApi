using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class ProdutoClienteSaidaService : ServiceBase<ProdutoClienteSaida>, IProdutoClienteSaidaService
    {
        private readonly IProdutoClienteSaidaRepository _produtoClienteSaidaRepository;

        public ProdutoClienteSaidaService(IProdutoClienteSaidaRepository produtoClienteSaidaRepository) :
            base(produtoClienteSaidaRepository)
        {
            _produtoClienteSaidaRepository = produtoClienteSaidaRepository;
        }

        public async Task<IEnumerable<object>> GetAllProdutoClienteSaida(int empresaId)
        {
            return await _produtoClienteSaidaRepository.GetAllProdutoClienteSaida(empresaId);
        }


        public async Task<ProdutoClienteSaida> GetProdutoClienteSaida(int numeroPedido, int empresaId)
        {
            return await _produtoClienteSaidaRepository.GetProdutoClienteSaida(numeroPedido, empresaId);
        }


        public async Task<IEnumerable<object>> GetProdutoClienteSaidaPagination(int pageNumber, int pageSize, System.Func<ProdutoClienteSaida, int> orderByFunc, System.Func<ProdutoClienteSaida, bool> countFunc, int empresaId)
        {
            return
                await
                    _produtoClienteSaidaRepository.GetProdutoClienteSaidaPagination(pageNumber, pageSize, orderByFunc,
                        countFunc, empresaId);

        }
    }

}
