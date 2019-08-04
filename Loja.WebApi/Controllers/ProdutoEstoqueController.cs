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
    
    [RoutePrefix("api/ProdutoEstoque")]
    public class ProdutoEstoqueController : BaseController
    {
        private readonly IProdutoEstoqueAppService _produtoEstoqueApp;

        public ProdutoEstoqueController(IProdutoEstoqueAppService produtoEstoqueApp)
        {
            _produtoEstoqueApp = produtoEstoqueApp;
        }

        public async Task<List<ProdutoEstoque>> GetProdutoEstoque(int empresaId)
        {
            try
            {
                return await _produtoEstoqueApp
                    .GetAll(estoque => estoque.Ativo == true
                    && estoque.EmpresaId == empresaId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<object> GetByIdProdutoEstoque(int id, int empresaId)
        {
            return await _produtoEstoqueApp.GetByIdProdutoEstoque(id, empresaId);
        }

        public async Task<List<ProdutoEstoque>> Get(string val, int empresaId)
        {
            try
            {
                return await _produtoEstoqueApp.GetProdutoEstoque(val, empresaId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        // GET api/<controller>/5
        public async Task<ProdutoEstoque> Get(int id)
        {
            try
            {
                return await _produtoEstoqueApp.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST api/<controller>
        public async void Post([FromBody]ProdutoEstoque value)
        {
            try
            {
                await _produtoEstoqueApp.Add(value);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // PUT api/<controller>/5
        public async void Put(int id, [FromBody]ProdutoEstoque value)
        {
            try
            {
                await _produtoEstoqueApp.Update(value);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        public async void Delete(ProdutoEstoque value)
        {
            try
            {
                await _produtoEstoqueApp.RemovePhysical(value);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}