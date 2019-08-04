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

    public class ProdutoClienteSaidaController : BaseController
    {
        private readonly IProdutoClienteSaidaAppService _produtoClienteSaidaAppService;

        public ProdutoClienteSaidaController(IProdutoClienteSaidaAppService produtoClienteSaidaAppService)
        {
            _produtoClienteSaidaAppService = produtoClienteSaidaAppService;
        }

        [HttpGet, Route("api/ProdutoClienteSaida/{pageNumber}/{pagerSize}/{empresaId}")]
        public async Task<IEnumerable<object>> GetPaginationProdutoClienteSaida(int pageNumber, int pagerSize, int empresaId)
        {
            try
            {
                return
                    await
                        _produtoClienteSaidaAppService.GetProdutoClienteSaidaPagination(pageNumber,
                        pagerSize,
                        saida => saida.ProdutoClienteSaidaId,
                        saida => saida.ProdutoClienteSaidaId > 0,
                         empresaId
                         );
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



        [HttpGet, Route("api/ProdutoClienteSaida/ProdutoClienteSaidaAll")]
        public async Task<IEnumerable<object>> GetAllProdutoClienteSaida(int empresaId)
        {
            try
            {
                return await _produtoClienteSaidaAppService.GetAllProdutoClienteSaida(empresaId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet, Route("api/ProdutoClienteSaida")]
        public async Task<List<ProdutoClienteSaida>> Get()
        {
            try
            {
                return await _produtoClienteSaidaAppService.GetAll(saida => saida.Ativo == true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        [HttpGet, Route("api/ProdutoClienteSaida")]
        public async Task<ProdutoClienteSaida> GetProdutoClienteSaida(int numeroPedido, int empresaId)
        {
            try
            {
                return await _produtoClienteSaidaAppService.GetProdutoClienteSaida(numeroPedido, empresaId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet, Route("api/ProdutoClienteSaida")]
        public async Task<ProdutoClienteSaida> Get(int id)
        {
            try
            {
                return await _produtoClienteSaidaAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST api/<controller>
        [HttpPost, Route("api/ProdutoClienteSaida")]
        public async Task<HttpResponseMessage> Post([FromBody] ProdutoClienteSaida produtoClienteSaidas)
        {
            try
            {
                await _produtoClienteSaidaAppService.Add(produtoClienteSaidas);
                NotificationHub.SendMessageNew(string.Format("Pedido efetuado com Sucesso {0}", Guid.NewGuid()));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }

        }

        // PUT api/<controller>/5
        [HttpPut, Route("api/ProdutoClienteSaida")]
        public async Task<HttpResponseMessage> Put([FromBody] ProdutoClienteSaida produtoClienteSaidas)
        {
            try
            {
                await _produtoClienteSaidaAppService.Update(produtoClienteSaidas);
                NotificationHub.SendMessageNew(string.Format("Pedido Alterado com Sucesso {0}", Guid.NewGuid()));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete, Route("api/ProdutoClienteSaida")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                await _produtoClienteSaidaAppService.RemoveLogic(id, null);
                NotificationHub.SendMessageNew(string.Format("Pedido Excluido com Sucesso {0}", Guid.NewGuid()));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}