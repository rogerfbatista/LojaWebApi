using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.WebApi.Attribute;
using Loja.WebApi.Controllers.Base;
using Loja.WebApi.Security;

namespace Loja.WebApi.Controllers
{


    public class UsuarioPerfilMenuController : BaseController
    {
        private readonly IUsuarioPerfilMenuAppService _usuarioPerfilMenuAppService;

        public UsuarioPerfilMenuController(IUsuarioPerfilMenuAppService usuarioPerfilMenuAppService)
        {
            _usuarioPerfilMenuAppService = usuarioPerfilMenuAppService;
        }


        [HttpGet, CacheClient(Duration = 2880), Route("api/UsuarioPerfilMenu/Menu/{idPerfil}/{empresaId}/{token}")]
        public async Task<List<UsuarioPerfilMenu>> GetUsuarioPerfilMenu(int idPerfil,int empresaId,  string token)
        {
            try
            {
                return
                    await
                        _usuarioPerfilMenuAppService.GetAll(
                            menu => menu.Menu.MenuTipoId == 1
                                    && menu.Ativo == true
                                    && menu.UsuarioPerfilId == idPerfil
                                    && menu.Menu.EmpresaId == empresaId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        //[HttpGet, CacheClient(Duration = 2880), Route("api/UsuarioPerfilMenu/Menu/{usuarioPerfilId}/{empresaId}/{token}")]
        //public async Task<IEnumerable<object>> GetUsuarioPerfilMenu(int usuarioPerfilId, int empresaId, string token)
        //{
        //    try
        //    {
                
        //          return  await _usuarioPerfilMenuAppService.GetAllMenu(usuarioPerfilId, empresaId);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }

        //}

        [Route("api/UsuarioPerfilMenu")]
        public async Task<List<UsuarioPerfilMenu>> Get()
        {
            try
            {
                return await _usuarioPerfilMenuAppService.GetAll(menu => menu.Ativo == true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        // GET api/<controller>/5
         [HttpGet, Route("api/UsuarioPerfilMenu/{id}")]
        public async Task<UsuarioPerfilMenu> Get(int id)
        {
            try
            {
                return await _usuarioPerfilMenuAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST api/<controller>
          [HttpPost, Route("api/UsuarioPerfilMenu")]
        public async void Post([FromBody]UsuarioPerfilMenu value)
        {
            try
            {
                await _usuarioPerfilMenuAppService.Add(value);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // PUT api/<controller>/5
          [HttpPut, Route("api/UsuarioPerfilMenu/{id}")]
        public async void Put(int id, [FromBody]UsuarioPerfilMenu value)
        {
            try
            {
                await _usuarioPerfilMenuAppService.Update(value);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete, Route("api/UsuarioPerfilMenu")]
        public async void Delete(UsuarioPerfilMenu value)
        {
            try
            {
                await _usuarioPerfilMenuAppService.RemovePhysical(value);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}