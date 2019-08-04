using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja.Application.Interfaces;
using Loja.Common.Validation;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class ProdutoFornecedorEntradaAppService : AppServiceBase<ProdutoFornecedorEntrada>,
        IProdutoFornecedorEntradaAppService
    {

        private readonly IProdutoFornecedorEntradaService _produtoFornecedorEntradaService;
        private readonly IProdutoEstoqueService _produtoEstoqueService;


        public ProdutoFornecedorEntradaAppService(IProdutoFornecedorEntradaService produtoFornecedorEntradaService, IProdutoEstoqueService produtoEstoqueService) :
            base(produtoFornecedorEntradaService)
        {
            _produtoFornecedorEntradaService = produtoFornecedorEntradaService;
            _produtoEstoqueService = produtoEstoqueService;
        }


        public new async Task Add(List<ProdutoFornecedorEntrada> obj)
        {
            foreach (var item in obj)
            {
                var objList = await _produtoFornecedorEntradaService.GetAll(entrada => entrada.NotaFiscalId == item.NotaFiscalId && entrada.EmpresaId == item.EmpresaId);

                AssertionConcern.AssertArgumentFalse(objList.Any(), "Nota fiscal ja cadastrada");
            }

            await _produtoFornecedorEntradaService.Add(obj);

            //atualizar estoque

            foreach (var item in obj.Where(item => item.ProdutoId != null))
            {
                var estoque = await
                    _produtoEstoqueService.GetProdutoEstoque(
                        produtoEstoque =>
                            produtoEstoque.EmpresaId == item.EmpresaId && produtoEstoque.ProdutoId == item.ProdutoId);


                if (estoque == null)
                {
                    estoque = new ProdutoEstoque(0, item.EmpresaId, item.ProdutoId, item.QuantidadeEntrada, item.ValorUnitario, true);
                    await _produtoEstoqueService.Add(estoque);
                }
                else
                {
                    var quantEstoque = estoque.QuantidadeEstoque;
                    quantEstoque += item.QuantidadeEntrada;
                    estoque.SetEstoque(quantEstoque);
                    estoque.SetValorVenda(item.ValorUnitario);
                    await _produtoEstoqueService.Update(estoque);
                }
            }

        }

        public async Task RemoveLogic(string notafiscal)
        {
            var produtoFornecedorEntrada = await
                _produtoFornecedorEntradaService.GetAll(entrada => entrada.NotaFiscalId == notafiscal && entrada.Ativo == true);

            foreach (var item in produtoFornecedorEntrada)
            {
                item.SetAtivo();
                await _produtoFornecedorEntradaService.Update(item);
            }


            //atualizar estoque

            foreach (var item in produtoFornecedorEntrada.Where(item => item.ProdutoId != null))
            {
                var estoque = await
                    _produtoEstoqueService.GetProdutoEstoque(
                        produtoEstoque =>
                            produtoEstoque.EmpresaId == item.EmpresaId && produtoEstoque.ProdutoId == item.ProdutoId);



                var quantEstoque = estoque.QuantidadeEstoque;
                quantEstoque -= item.QuantidadeEntrada;
                estoque.SetEstoque(quantEstoque);
                await _produtoEstoqueService.Update(estoque);

            }
        }

        public new async Task Update(List<ProdutoFornecedorEntrada> obj)
        {
            var listaRemoveobj = obj.FindAll(entrada => entrada.Ativo == false);
            var listaAddobj = obj.FindAll(entrada => entrada.ProdutoEntradaId == 0);

            #region  //atualizar estoque Remove


            await _produtoFornecedorEntradaService.Update(listaRemoveobj);

            foreach (var item in listaRemoveobj.Where(item => item.ProdutoId != null))
            {
                var estoque = await
                    _produtoEstoqueService.GetProdutoEstoque(
                        produtoEstoque =>
                            produtoEstoque.EmpresaId == item.EmpresaId && produtoEstoque.ProdutoId == item.ProdutoId);



                var quantEstoque = estoque.QuantidadeEstoque;
                quantEstoque -= item.QuantidadeEntrada;
                estoque.SetEstoque(quantEstoque);
                await _produtoEstoqueService.Update(estoque);

            }

            #endregion

            #region  //atualizar estoque add

            await _produtoFornecedorEntradaService.Add(listaAddobj);

            foreach (var item in listaAddobj.Where(item => item.ProdutoId != null))
            {
                var estoque = await
                    _produtoEstoqueService.GetProdutoEstoque(
                        produtoEstoque =>
                            produtoEstoque.EmpresaId == item.EmpresaId && produtoEstoque.ProdutoId == item.ProdutoId);


                if (estoque == null)
                {
                    estoque = new ProdutoEstoque(0, item.EmpresaId, item.ProdutoId, item.QuantidadeEntrada, item.ValorUnitario, true);
                    await _produtoEstoqueService.Add(estoque);
                }
                else
                {

                    var quantEstoque = estoque.QuantidadeEstoque;
                    quantEstoque += item.QuantidadeEntrada;
                    estoque.SetEstoque(quantEstoque);
                    estoque.SetValorVenda(item.ValorUnitario);
                    await _produtoEstoqueService.Update(estoque);
                }
            }

            #endregion



        }


        public async Task<IEnumerable<object>> GetAllProdutoFornecedorEntrada(int empresaId)
        {
            return await _produtoFornecedorEntradaService.GetAllProdutoFornecedorEntrada(empresaId);
        }
    }

}
