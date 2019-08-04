using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class ProdutoClienteSaidaAppService : AppServiceBase<ProdutoClienteSaida>, IProdutoClienteSaidaAppService
    {
        private readonly IProdutoClienteSaidaService _produtoClienteSaidaService;

        private readonly IProdutoClienteSaidaItemService _produtoClienteSaidaItemService;


        private readonly IProdutoEstoqueService _produtoEstoqueService;

        public ProdutoClienteSaidaAppService(IProdutoClienteSaidaService produtoClienteSaidaService,
            IProdutoEstoqueService produtoEstoqueService, IProdutoClienteSaidaItemService produtoClienteSaidaItemService)
            : base(produtoClienteSaidaService)
        {
            _produtoClienteSaidaService = produtoClienteSaidaService;
            _produtoEstoqueService = produtoEstoqueService;
            _produtoClienteSaidaItemService = produtoClienteSaidaItemService;
        }

        public new async Task Add(ProdutoClienteSaida obj)
        {
            await _produtoClienteSaidaService.Add(obj);

            //  atualizar estoque
            foreach (var item in obj.ProdutoClienteSaidaItems.Where(item => item.ProdutoId != null))
            {


                var estoque = await
                    _produtoEstoqueService.GetProdutoEstoque(
                        produtoEstoque =>
                            produtoEstoque.EmpresaId == obj.EmpresaId && produtoEstoque.ProdutoId == item.ProdutoId);


                var quantEstoque = estoque.QuantidadeEstoque;
                quantEstoque -= item.QuantidadeSaida;
                estoque.SetEstoque(quantEstoque);
                await _produtoEstoqueService.Update(estoque);

            }
        }

        public new async Task RemoveLogic(int id, ProdutoClienteSaida obj)
        {

            var produtoClienteSaida = await _produtoClienteSaidaService.GetById(id);

            produtoClienteSaida.SetAtivoFalse();

            await _produtoClienteSaidaService.RemoveLogic(id, produtoClienteSaida);

            foreach (var item in produtoClienteSaida.ProdutoClienteSaidaItems)
            {
                item.SetAtivoFalse();

                await _produtoClienteSaidaItemService.RemoveLogic(id, item);
            }


            ////atualizar estoque
            foreach (var item in produtoClienteSaida.ProdutoClienteSaidaItems)
            {
                var estoque = await
                    _produtoEstoqueService.GetProdutoEstoque(
                        produtoEstoque =>
                            produtoEstoque.EmpresaId == produtoClienteSaida.EmpresaId && produtoEstoque.ProdutoId == item.ProdutoId);

                var quantEstoque = estoque.QuantidadeEstoque;
                quantEstoque += item.QuantidadeSaida;
                estoque.SetEstoque(quantEstoque);
                await _produtoEstoqueService.Update(estoque);

            }

        }

        public async Task<IEnumerable<object>> GetAllProdutoClienteSaida(int empresaId)
        {
            return await _produtoClienteSaidaService.GetAllProdutoClienteSaida(empresaId);
        }


        public async Task<ProdutoClienteSaida> GetProdutoClienteSaida(int numeroPedido, int empresaId)
        {
            return await _produtoClienteSaidaService.GetProdutoClienteSaida(numeroPedido, empresaId);
        }


        public async Task<IEnumerable<object>> GetProdutoClienteSaidaPagination(int pageNumber, int pageSize, System.Func<ProdutoClienteSaida, int> orderByFunc, System.Func<ProdutoClienteSaida, bool> countFunc, int empresaId)
        {
            return await _produtoClienteSaidaService.GetProdutoClienteSaidaPagination(pageNumber,
                pageSize,
                orderByFunc,
                countFunc,
                empresaId);

        }
    }

}
