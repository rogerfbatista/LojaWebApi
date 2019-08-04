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

    public class FornecedorController : BaseController
    {

        private readonly IFornecedorAppService _fornecedorAppService;

        public FornecedorController(IFornecedorAppService fornecedorAppService)
        {
            _fornecedorAppService = fornecedorAppService;
        }

        // GET api/<controller>
        // GET api/<controller>
        [HttpGet, Route("api/Fornecedor")]
        public async Task<List<Fornecedor>> Get()
        {
            try
            {
                return await _fornecedorAppService.GetAll(fornecedor => fornecedor.Ativo == true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet, CacheClient(Duration = 2880), Route("api/Fornecedor")]
        public async Task<List<Fornecedor>> Get(string val, int empresaId)
        {
            try
            {
                return await _fornecedorAppService.GetForncedor(val, empresaId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet, Route("api/Fornecedor/FornecedorAll")]
        public async Task<List<Fornecedor>> GetAllFornecedor(int empresaId)
        {
            try
            {
                return await _fornecedorAppService.GetAllFornecedor(empresaId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet, Route("api/Fornecedor")]
        public async Task<Fornecedor> Get(int id)
        {
            try
            {
                return await _fornecedorAppService.GetById(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        // POST api/<controller>
        [HttpPost, Route("api/Fornecedor")]
        public async Task<HttpResponseMessage> Post([FromBody]Fornecedor fornecedor)
        {
            try
            {
                await _fornecedorAppService.Add(fornecedor);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Fornecedor efetuado com Sucesso {0}-{1}", fornecedor.NomeFornecedor, fornecedor.FornecedorId));

                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        // PUT api/<controller>/5
        [HttpPut, Route("api/Fornecedor")]
        public async Task<HttpResponseMessage> Put([FromBody]Fornecedor fornecedor)
        {
            try
            {
                await _fornecedorAppService.Update(fornecedor);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Fornecedor Alterado com Sucesso {0}-{1}", fornecedor.NomeFornecedor, fornecedor.FornecedorId));

                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        // DELETE api/<controller>/5
        [HttpDelete, Route("api/Fornecedor")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                await _fornecedorAppService.RemoveLogic(id, null);
                NotificationHub.SendMessageNew(string.Format("Cadastro de Fornecedor Excluido com Sucesso {0}", id));
                return await Task.Factory.StartNew(() => new HttpResponseMessage { StatusCode = HttpStatusCode.OK });

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}