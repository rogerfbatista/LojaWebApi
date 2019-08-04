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
   
    [RoutePrefix("api/Empresa")]
    public class EmpresaController : BaseController
    {
        private readonly IEmpresaAppService _empresaAppService;



        public EmpresaController(IEmpresaAppService empresaAppService)
        {
            _empresaAppService = empresaAppService;

        }

        // GET api/<controller>
        public async Task<List<Empresa>> Get()
        {
            try
            {

                return await _empresaAppService.GetAll(empresa => empresa.Ativo == true);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        // GET api/<controller>/5
        public async Task<Empresa> Get(int id)
        {
            try
            {
                return await _empresaAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST api/<controller>
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody]Empresa empresa)
        {
            try
            {

                await _empresaAppService.Add(empresa);
                NotificationHub.SendMessageNew(
          string.Format("Cadastro de empresa efetuado com Sucesso {0}-{1}", empresa.NomeEmpresa, empresa.Contato));

                return await Task.Factory.StartNew(() => new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // PUT api/<controller>/5
        public async Task<HttpResponseMessage> Put([FromBody]Empresa empresa)
        {
            try
            {

                await _empresaAppService.Update(empresa);

                NotificationHub.SendMessageUpdate(
             string.Format("Cadastro de empresa alterado com Sucesso {0}-{1}", empresa.NomeEmpresa, empresa.Contato));

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


                await _empresaAppService.RemoveLogic(id, null);

                NotificationHub.SendMessageDelete(string.Format("Cadastro de empresa Excluido com Sucesso  {0}", id));

                return await Task.Factory.StartNew(() => new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}