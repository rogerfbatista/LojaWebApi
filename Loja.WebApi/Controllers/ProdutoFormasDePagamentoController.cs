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
   
    [RoutePrefix("api/ProdutoFormasDePagamento")]
    public class ProdutoFormasDePagamentoController : BaseController
    {
        private readonly IProdutoFormasDePagamentoAppService _produtoFormasDePagamentoAppService;

        public ProdutoFormasDePagamentoController(IProdutoFormasDePagamentoAppService produtoFormasDePagamentoAppService)
        {
            _produtoFormasDePagamentoAppService = produtoFormasDePagamentoAppService;
        }

        public async Task<List<ProdutoFormasDePagamento>> Get()
        {
            try
            {
                return await _produtoFormasDePagamentoAppService.GetAll(pagamento => pagamento.Ativo == true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        // GET api/<controller>/5
        public async Task<ProdutoFormasDePagamento> Get(int id)
        {
            try
            {
                return await _produtoFormasDePagamentoAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST api/<controller>
        public async void Post([FromBody]ProdutoFormasDePagamento value)
        {
            try
            {
                await _produtoFormasDePagamentoAppService.Add(value);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // PUT api/<controller>/5
        public async void Put(int id, [FromBody]ProdutoFormasDePagamento value)
        {
            try
            {
                await _produtoFormasDePagamentoAppService.Update(value);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        public async void Delete(ProdutoFormasDePagamento value)
        {
            try
            {
                await _produtoFormasDePagamentoAppService.RemovePhysical(value);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}