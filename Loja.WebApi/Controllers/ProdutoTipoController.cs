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
    
    [RoutePrefix("api/ProdutoTipo")]
    public class ProdutoTipoController : BaseController
    {
        private readonly IProdutoTipoAppService _produtoTipoAppService;

        public ProdutoTipoController(IProdutoTipoAppService produtoTipoAppService)
        {
            _produtoTipoAppService = produtoTipoAppService;
        }


        public async Task<List<ProdutoTipo>> Get()
        {
            try
            {
                return await _produtoTipoAppService.GetAll(tipo => tipo.Ativo == true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        // GET api/<controller>/5
        public async Task<ProdutoTipo> Get(int id)
        {
            try
            {
                return await _produtoTipoAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST api/<controller>
        public async Task<HttpResponseMessage> Post([FromBody]ProdutoTipo produtoTipo)
        {
            try
            {
                await _produtoTipoAppService.Add(produtoTipo);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Tipo de Produto Efetuado com Sucesso {0}-{1}", produtoTipo.NomeProdutoTipo, produtoTipo.ProdutoTipoId));
                return await Task.Factory.StartNew(() => new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // PUT api/<controller>/5
        public async Task<HttpResponseMessage> Put([FromBody]ProdutoTipo produtoTipo)
        {
            try
            {
                await _produtoTipoAppService.Update(produtoTipo);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Tipo de Produto Alterado com Sucesso {0}-{1}", produtoTipo.NomeProdutoTipo, produtoTipo.ProdutoTipoId));
                return await Task.Factory.StartNew(() => new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });
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
                await _produtoTipoAppService.RemoveLogic(id, null);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Tipo de Produto Excluido com Sucesso {0}", id));
                return await Task.Factory.StartNew(() => new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}