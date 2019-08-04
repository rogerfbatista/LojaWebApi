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

    [RoutePrefix("api/EmpresaContato")]
    public class EmpresaContatoController : BaseController
    {
        private readonly IEmpresaContatoAppService _empresaContatoAppService;

        public EmpresaContatoController(IEmpresaContatoAppService empresaContatoAppService)
        {
            _empresaContatoAppService = empresaContatoAppService;
        }


        public async Task<List<EmpresaContato>> Get()
        {
            try
            {
                return await _empresaContatoAppService.GetAll(contato => contato.Ativo == true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        // GET api/<controller>/5
        public async Task<EmpresaContato> Get(int id)
        {
            try
            {
                return await _empresaContatoAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST api/<controller>
        public async void Post([FromBody]EmpresaContato value)
        {
            try
            {
                await _empresaContatoAppService.Add(value);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // PUT api/<controller>/5
        public async void Put(int id, [FromBody]EmpresaContato value)
        {
            try
            {
                await _empresaContatoAppService.Update(value);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        public async void Delete(EmpresaContato value)
        {
            try
            {
                await _empresaContatoAppService.RemovePhysical(value);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}