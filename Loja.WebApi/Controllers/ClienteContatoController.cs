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
   
    [RoutePrefix("api/ClienteContato")]
    public class ClienteContatoController : BaseController
    {
        private readonly IClienteContatoAppService _clienteContatoAppService;

        public ClienteContatoController(IClienteContatoAppService clienteContatoAppService)
        {
            _clienteContatoAppService = clienteContatoAppService;
        }

        // GET api/<controller>
        public async Task<List<ClienteContato>> Get()
        {
            try
            {
                return await _clienteContatoAppService.GetAll(cliente => cliente.Ativo == true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        // GET api/<controller>/5
        public async Task<ClienteContato> Get(int id)
        {
            try
            {
                return await _clienteContatoAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST api/<controller>
        public async Task<HttpResponseMessage> Post([FromBody]ClienteContato clienteContato)
        {
            try
            {
                await _clienteContatoAppService.Add(clienteContato);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Contato de Cliente efetuado com Sucesso {0}",clienteContato.ClienteContatoId));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // PUT api/<controller>/5
        public async Task<HttpResponseMessage> Put([FromBody]ClienteContato clienteContato)
        {
            try
            {
                await _clienteContatoAppService.Update(clienteContato);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Contato de Cliente Alterado com Sucesso {0}", clienteContato.ClienteContatoId));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        public async Task<HttpResponseMessage> Delete(ClienteContato clienteContato)
        {
            try
            {
                await _clienteContatoAppService.RemovePhysical(clienteContato);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Contato de Cliente Excluido com Sucesso {0}", clienteContato.ClienteContatoId));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}