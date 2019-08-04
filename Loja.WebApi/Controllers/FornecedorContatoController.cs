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
   
    [RoutePrefix("api/FornecedorContato")]
    public class FornecedorContatoController : BaseController
    {
        private readonly IFornecedorContatoAppService _fornecedorContatoAppService;

        public FornecedorContatoController(IFornecedorContatoAppService fornecedorContatoAppService)
        {
            _fornecedorContatoAppService = fornecedorContatoAppService;
        }



        public async Task<List<FornecedorContato>> Get()
        {
            try
            {
                return await _fornecedorContatoAppService.GetAll(contato => contato.Ativo == true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        // GET api/<controller>/5
        public async Task<FornecedorContato> Get(int id)
        {
            try
            {
                return await _fornecedorContatoAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST api/<controller>
        public async Task<HttpResponseMessage> Post([FromBody]FornecedorContato fornecedorContato)
        {
            try
            {
                await _fornecedorContatoAppService.Add(fornecedorContato);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Fornecedor Contato Efetuado com Sucesso {0}", fornecedorContato.FornecedorContatoId));

                return await Task.Factory.StartNew(() => new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // PUT api/<controller>/5
        public async Task<HttpResponseMessage> Put(int id, [FromBody]FornecedorContato fornecedorContato)
        {
            try
            {
                await _fornecedorContatoAppService.Update(fornecedorContato);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Fornecedor Contato Alterado com Sucesso {0}", fornecedorContato.FornecedorContatoId));

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
                await _fornecedorContatoAppService.RemoveLogic(id, null);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Forncedor Contato Excluido com Sucesso {0}", id));
                return await Task.Factory.StartNew(() => new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}