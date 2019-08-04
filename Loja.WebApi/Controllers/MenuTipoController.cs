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
  
    [RoutePrefix("api/MenuTipo")]
    public class MenuTipoController : BaseController
    {
        private readonly IMenuTipoAppService _menuTipoAppServiceAppService;

        public MenuTipoController(IMenuTipoAppService menuTipoAppServiceAppService)
        {
            _menuTipoAppServiceAppService = menuTipoAppServiceAppService;
        }


        public async Task<List<MenuTipo>> Get()
        {
            try
            {
                return await _menuTipoAppServiceAppService.GetAll(menu => menu.Ativo == true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        // GET api/<controller>/5
        public async Task<MenuTipo> Get(int id)
        {
            try
            {
                return await _menuTipoAppServiceAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST api/<controller>
        public async void Post([FromBody]MenuTipo value)
        {
            try
            {
                await _menuTipoAppServiceAppService.Add(value);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // PUT api/<controller>/5
        public async void Put(int id, [FromBody]MenuTipo value)
        {
            try
            {
                await _menuTipoAppServiceAppService.Update(value);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        public async void Delete(MenuTipo value)
        {
            try
            {
                await _menuTipoAppServiceAppService.RemovePhysical(value);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}