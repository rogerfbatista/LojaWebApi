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

   
    [RoutePrefix("api/EmpresaCliente")]
    public class EmpresaClienteController : BaseController
    {
        private readonly IEmpresaClienteAppService _empresaClienteAppService;

        public EmpresaClienteController(IEmpresaClienteAppService empresaClienteAppService)
        {
            _empresaClienteAppService = empresaClienteAppService;
        }


        public async Task<List<EmpresaCliente>> Get()
        {
            try
            {
                return await _empresaClienteAppService.GetAll(cliente => cliente.Ativo == true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        // GET api/<controller>/5
        public async Task<EmpresaCliente> Get(int id)
        {
            try
            {
                return await _empresaClienteAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST api/<controller>
        public async void Post([FromBody]EmpresaCliente value)
        {
            try
            {
                await _empresaClienteAppService.Add(value);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // PUT api/<controller>/5
        public async void Put(int id, [FromBody]EmpresaCliente value)
        {
            try
            {
                await _empresaClienteAppService.Update(value);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        public async void Delete(EmpresaCliente value)
        {
            try
            {
                await _empresaClienteAppService.RemovePhysical(value);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}