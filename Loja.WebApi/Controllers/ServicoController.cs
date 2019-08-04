using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.WebApi.Controllers.Base;
using Loja.WebApi.notification;
using Loja.WebApi.Security;

namespace Loja.WebApi.Controllers
{

    public class ServicoController : BaseController
    {

        private readonly IServicoAppService _servicoAppService;

        public ServicoController(IServicoAppService servicoAppService)
        {
            _servicoAppService = servicoAppService;
        }


        // GET api/<controller>/5
        [HttpGet, Route("api/Servico")]
        public async Task<Servico> Get(int id)
        {
            try
            {
                return await _servicoAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpGet, Route("api/Servico")]
        public async Task<List<Servico>> Get()
        {
            try
            {
                return await _servicoAppService.GetAll(servico => servico.Ativo == true);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        // POST api/<controller>
        [HttpPost, Route("api/Servico")]
        public async Task<HttpResponseMessage> Post([FromBody]Servico servico)
        {
            try
            {
                await _servicoAppService.Add(servico);
                NotificationHub.SendMessageNew(string.Format("Servico cadastrado com Sucesso {0}", Guid.NewGuid()));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        // PUT api/<controller>/5
        [HttpPut, Route("api/Servico")]
        public async Task<HttpResponseMessage> Put([FromBody]Servico servico)
        {
            try
            {
                await _servicoAppService.Update(servico);
                NotificationHub.SendMessageNew(string.Format("Servico Alterado com Sucesso {0}", Guid.NewGuid()));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete, Route("api/Servico")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                await _servicoAppService.RemoveLogic(id, null);
                NotificationHub.SendMessageNew(string.Format("Servico Excluido com Sucesso {0}", Guid.NewGuid()));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });

            }
            catch (Exception ex)
            {


                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}