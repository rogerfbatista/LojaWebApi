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

      [RoutePrefix("api/Menu")]
    public class MenuController : BaseController
    {

        private readonly IMenuAppService _menuAppService;

        public MenuController(IMenuAppService menuAppService)
        {
            _menuAppService = menuAppService;
        }


        [HttpGet]
        public async Task<List<Menu>> GetMenu(int empresaId)
        {
            try
            {
                return await _menuAppService.GetAll(menu => menu.Ativo == true && menu.EmpresaId == empresaId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        [HttpGet]
        public async Task<List<Menu>> GetMenuPrincipal(int menuTipoId)
        {
            try
            {
                return await _menuAppService.GetAll(menu => menu.Ativo == true && menu.MenuTipoId == menuTipoId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet]
        public async Task<Menu> Get(int id)
        {
            try
            {
                return await _menuAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST api/<controller>
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody]Menu menu)
        {
            try
            {
                await _menuAppService.Add(menu);
                NotificationHub.SendMessageNew(string.Format("Menu Cadastrado com Sucesso {0}", Guid.NewGuid()));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody]Menu menu)
        {
            try
            {
                await _menuAppService.Update(menu);
                NotificationHub.SendMessageNew(string.Format("Menu Alterado com Sucesso {0}", Guid.NewGuid()));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                await _menuAppService.RemoveLogic(id, null);
                NotificationHub.SendMessageNew(string.Format("Menu Excluido com Sucesso {0}", Guid.NewGuid()));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}