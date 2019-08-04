using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.WebApi.Attribute;
using Loja.WebApi.Controllers.Base;
using Loja.WebApi.notification;
using Loja.WebApi.Security;

namespace Loja.WebApi.Controllers
{

    public class ProdutoFornecedorEntradaController : BaseController
    {
        private readonly IProdutoFornecedorEntradaAppService _produtoFornecedorEntradaAppService;

        public ProdutoFornecedorEntradaController(IProdutoFornecedorEntradaAppService produtoFornecedorEntradaAppService)
        {
            _produtoFornecedorEntradaAppService = produtoFornecedorEntradaAppService;
        }

        [HttpGet, Route("api/ProdutoFornecedorEntrada")]
        public async Task<List<ProdutoFornecedorEntrada>> Get(string notaFiscal, int empresaId)
        {
            try
            {
                return await _produtoFornecedorEntradaAppService
                    .GetAll(entrada => entrada.Ativo == true && entrada.NotaFiscalId == notaFiscal
                             && entrada.EmpresaId == empresaId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet, Route("api/ProdutoFornecedorEntrada/ProdutoFornecedorEntradaAll")]
        public async Task<IEnumerable<object>> GetAllProdutoFornecedorEntrada(int empresaId)
        {
            try
            {
                return await _produtoFornecedorEntradaAppService.GetAllProdutoFornecedorEntrada(empresaId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet, Route("api/ProdutoFornecedorEntrada")]
        public async Task<ProdutoFornecedorEntrada> Get(int id)
        {
            try
            {
                return await _produtoFornecedorEntradaAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpPost, Route("api/ProdutoFornecedorEntrada")]
        public async Task<HttpResponseMessage> Post([FromBody]List<ProdutoFornecedorEntrada> produtoFornecedorEntrada)
        {
            try
            {

                await _produtoFornecedorEntradaAppService.Add(produtoFornecedorEntrada);
                NotificationHub.SendMessageNew(string.Format("Entrada de Produto efetuado com Sucesso {0}", Guid.NewGuid()));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpPut, Route("api/ProdutoFornecedorEntrada")]
        public async Task<HttpResponseMessage> Put([FromBody]List<ProdutoFornecedorEntrada> produtoFornecedorEntrada)
        {
            try
            {
                await _produtoFornecedorEntradaAppService.Update(produtoFornecedorEntrada);
                NotificationHub.SendMessageNew(string.Format("Entrada de Produto alterada com Sucesso {0}", Guid.NewGuid()));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete, Route("api/ProdutoFornecedorEntrada")]
        public async Task<HttpResponseMessage> Delete(string id)
        {
            try
            {
                await _produtoFornecedorEntradaAppService.RemoveLogic(id);
                NotificationHub.SendMessageNew(string.Format("Entrada de Produto Excluida com Sucesso {0}", Guid.NewGuid()));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}