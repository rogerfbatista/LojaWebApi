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
   
    [RoutePrefix("api/UsuarioPerfil")]
    public class UsuarioPerfilController : BaseController
    {
        private readonly IUsuarioPerfilAppService _usuarioPerfilAppService;

        public UsuarioPerfilController(IUsuarioPerfilAppService usuarioPerfilAppService)
        {
            _usuarioPerfilAppService = usuarioPerfilAppService;
        }



        public async Task<List<UsuarioPerfil>> Get()
        {
            try
            {
                return await _usuarioPerfilAppService.GetAll(perfil => perfil.Ativo == true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        // GET api/<controller>/5
        public async Task<UsuarioPerfil> Get(int id)
        {
            try
            {
                return await _usuarioPerfilAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST api/<controller>
        public async Task<HttpResponseMessage> Post([FromBody]UsuarioPerfil usuarioPerfil)
        {
            try
            {
                await _usuarioPerfilAppService.Add(usuarioPerfil);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Pefil Efetuado com Sucesso {0}", Guid.NewGuid()));
                return await Task.Factory.StartNew(() => new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // PUT api/<controller>/5
        public async Task<HttpResponseMessage> Put([FromBody]UsuarioPerfil usuarioPerfil)
        {
            try
            {
                await _usuarioPerfilAppService.Update(usuarioPerfil);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Pefil Alterado com Sucesso {0}",Guid.NewGuid()));

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
                await _usuarioPerfilAppService.RemoveLogic(id,null);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Pefil Excluido com Sucesso {0}", Guid.NewGuid()));
                return await Task.Factory.StartNew(() => new HttpResponseMessage() { StatusCode = HttpStatusCode.OK });

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}