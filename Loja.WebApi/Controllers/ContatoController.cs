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

   
    [RoutePrefix("api/Contato")]
    public class ContatoController : BaseController
    {
        private readonly IEmailAppService _emailAppService;

        public ContatoController(IEmailAppService emailAppService)
        {
            _emailAppService = emailAppService;
        }


        // POST api/<controller>
        public async Task<HttpResponseMessage> Post([FromBody] Email email)
        {
            try
            {
                //var corpo = new StringBuilder().Append(email.Mensagem);

                //await new EmailManager().EnviarEmail(email.Assunto, corpo, new List<string>()
                // {
                //     "rogerfbatista@sonicti.somee.com"
                // }, new List<Attachment>());

                NotificationHub.SendMessageNew(
          string.Format("Mensagem enviada com Sucesso {0}", Guid.NewGuid()));

                return await Task.Factory.StartNew(() => new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<List<Email>> Get()
        {
            try
            {

                return await _emailAppService.GetAll();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        // GET api/<controller>/5
        public async Task<Email> Get(int id)
        {
            try
            {
                return await _emailAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        // PUT api/<controller>/5
        public async Task<HttpResponseMessage> Put([FromBody]Email email)
        {
            try
            {
                await _emailAppService.Update(email);

                NotificationHub.SendMessageUpdate(
             string.Format("Alterado com Sucesso {0}", Guid.NewGuid()));

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
                await _emailAppService.RemoveLogic(id, null);

                NotificationHub.SendMessageDelete(string.Format("Excluido com Sucesso  {0}", id));

                return await Task.Factory.StartNew(() => new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }


}