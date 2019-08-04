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

    public class UsuarioController : BaseController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }


        [HttpGet, Route("api/Usuario")]
        public async Task<List<Usuario>> Get()
        {
            try
            {
                return await _usuarioAppService.GetAll(usuario => usuario.Ativo == true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        // GET api/<controller>/5
        [HttpGet, Route("api/Usuario")]
        public async Task<Usuario> Get(int id)
        {
            try
            {
                return await _usuarioAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST api/<controller>]
           [HttpPost, Route("api/Usuario")]
        public async Task<HttpResponseMessage> Post([FromBody]Usuario usuario)
        {
            try
            {
                await _usuarioAppService.Add(usuario);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Usuario efetuado com Sucesso {0}-{1}", usuario.NomeUsuario, usuario.UsuarioId));
                return await Task.Factory.StartNew(() => new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // PUT api/<controller>/5
           [HttpPut, Route("api/Usuario")]
        public async Task<HttpResponseMessage> Put([FromBody]Usuario usuario)
        {
            try
            {
                await _usuarioAppService.Update(usuario);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Usuario Alterado com Sucesso {0}-{1}", usuario.NomeUsuario, usuario.UsuarioId));
                return await Task.Factory.StartNew(() => new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE api/<controller>/5

           [HttpDelete, Route("api/Usuario")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                await _usuarioAppService.RemoveLogic(id, null);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Usuario Excluido com Sucesso {0}", id));
                return await Task.Factory.StartNew(() => new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}