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
    
    [RoutePrefix("api/EmpresaFornecedor")]
    public class EmpresaFornecedorController : BaseController
    {
        private readonly IEmpresaFornecedorAppService _empresaFornecedorAppService;

        public EmpresaFornecedorController(IEmpresaFornecedorAppService empresaFornecedorAppService)
        {
            _empresaFornecedorAppService = empresaFornecedorAppService;
        }

        // GET api/<controller>
        // GET api/<controller>
        public async Task<List<EmpresaFornecedor>> Get()
        {
            try
            {
                return await _empresaFornecedorAppService.GetAll(cliente => cliente.Ativo == true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        // GET api/<controller>/5
        public async Task<EmpresaFornecedor> Get(int id)
        {
            try
            {
                return await _empresaFornecedorAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        // POST api/<controller>
        public async void Post([FromBody]EmpresaFornecedor value)
        {
            try
            {
                await _empresaFornecedorAppService.Add(value);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        // PUT api/<controller>/5
        public async void Put(int id, [FromBody]EmpresaFornecedor value)
        {
            try
            {
                await _empresaFornecedorAppService.Update(value);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        // DELETE api/<controller>/5
        public async void Delete(EmpresaFornecedor value)
        {
            try
            {
                await _empresaFornecedorAppService.RemovePhysical(value);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}