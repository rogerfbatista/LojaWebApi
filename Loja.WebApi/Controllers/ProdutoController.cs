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
   
    [RoutePrefix("api/Produto")]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        public async Task<List<Produto>> Get()
        {
            try
            {
                return await _produtoAppService.GetAll(produto => produto.Ativo == true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        // GET api/<controller>/5
        public async Task<Produto> Get(int id)
        {
            try
            {
                return await _produtoAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<List<Produto>> Get(string val, int empresaId)
        {
            try
            {
                return await _produtoAppService.GetProduto(val, empresaId);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST api/<controller>
        public async Task<HttpResponseMessage> Post([FromBody]Produto produto)
        {
            try
            {
                await _produtoAppService.Add(produto);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Produto efetuado com Sucesso {0}-{1}", produto.NomeProduto, produto.ProdutoId));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // PUT api/<controller>/5
        public async Task<HttpResponseMessage> Put([FromBody]Produto produto)
        {
            try
            {
                await _produtoAppService.Update(produto);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Produto Alterado com Sucesso {0}-{1}", produto.NomeProduto, produto.ProdutoId));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                await _produtoAppService.RemoveLogic(id, null);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Produto efetuado com Sucesso {0}", id));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}