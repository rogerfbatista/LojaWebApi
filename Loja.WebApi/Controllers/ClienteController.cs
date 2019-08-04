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

    public class ClienteController : BaseController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }


        // GET api/<controller>
        [HttpGet, Route("api/Cliente")]
        public async Task<List<Cliente>> Get()
        {
            try
            {
                return await _clienteAppService.GetAll(cliente => cliente.Ativo == true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET api/<controller>
        [HttpGet, Route("api/Cliente")]
        public async Task<List<Cliente>> Get(string val, int empresaId)
        {
            try
            {
                return await _clienteAppService.GetCliente(val, empresaId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet, Route("api/Cliente/ClienteAll")]
        public async Task<List<Cliente>> GetAllCliente(int empresaId)
        {
            try
            {
                return await _clienteAppService.GetAllCliente(empresaId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet, Route("api/Cliente")]
        public async Task<Cliente> Get(int id)
        {
            try
            {
                return await _clienteAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        // POST api/<controller>
        [HttpPost, Route("api/Cliente")]
        public async Task<HttpResponseMessage> Post([FromBody]Cliente cliente)
        {
            try
            {
                await _clienteAppService.Add(cliente);
                NotificationHub.SendMessageNew(string.Format("Cadastro de cliente efetuado com Sucesso {0}-{1}", cliente.NomeCliente, cliente.ClienteId));

                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        // PUT api/<controller>/5
        [HttpPut, Route("api/Cliente")]
        public async Task<HttpResponseMessage> Put([FromBody]Cliente cliente)
        {
            try
            {
                await _clienteAppService.Update(cliente);
                NotificationHub.SendMessageNew(string.Format("Cadastro de cliente Alterado com Sucesso {0}-{1}", cliente.NomeCliente, cliente.ClienteId));

                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        // DELETE api/<controller>/5
        [HttpDelete, Route("api/Cliente")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                await _clienteAppService.RemoveLogic(id, null);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Cliente Excluido com Sucesso {0}", id));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}