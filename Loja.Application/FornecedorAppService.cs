using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class FornecedorAppService : AppServiceBase<Fornecedor>, IFornecedorAppService
    {
        private readonly IFornecedorService _fornecedorService;
        private readonly IFornecedorContatoService _fornecedorContatoService;
        private readonly IEmpresaFornecedorService _empresaFornecedorService;

        public FornecedorAppService(IFornecedorService fornecedorService,
            IFornecedorContatoService fornecedorContatoService,
            IEmpresaFornecedorService empresaFornecedorService)
            : base(fornecedorService)
        {
            _fornecedorService = fornecedorService;
            _fornecedorContatoService = fornecedorContatoService;
            _empresaFornecedorService = empresaFornecedorService;
        }

        public new async Task RemoveLogic(int id, Fornecedor obj)
        {
            var fornecedor = await _fornecedorService.GetById(id);

            fornecedor.Ativo = false;

            foreach (var contato in fornecedor.FornecedorContatos)
            {
                contato.Fornecedor = null;
            }

            await _fornecedorService.RemoveLogic(id, fornecedor);

            foreach (var contato in fornecedor.FornecedorContatos)
            {
                contato.Ativo = false;
                contato.Fornecedor = null;

                await _fornecedorContatoService.RemoveLogic(id, contato);

            }

            foreach (var empresaFornecedor in fornecedor.EmpresaFornecedores)
            {

                empresaFornecedor.Empresa = null;
                empresaFornecedor.Fornecedor = null;
                empresaFornecedor.Ativo = false;
                await _empresaFornecedorService.RemoveLogic(id, empresaFornecedor);

            }

        }

        public new async Task Update(Fornecedor obj)
        {
            var listContatoAdd = new List<FornecedorContato>();
            var listContatoUpdate = new List<FornecedorContato>();

            foreach (var contato in obj.FornecedorContatos)
            {
                if (contato.FornecedorContatoId == 0)
                    listContatoAdd.Add(contato);


                if (contato.Ativo == false)
                    listContatoUpdate.Add(contato);
            }
            await _fornecedorService.Update(obj);

            //add fornecedorContato
            foreach (var fornecedorContato in listContatoAdd)
            {
                await _fornecedorContatoService.Add(fornecedorContato);
            }


            foreach (var fornecedorContato in listContatoUpdate)
            {
                fornecedorContato.Fornecedor = null;

                await _fornecedorContatoService.Update(fornecedorContato);
            }
        }


        public async Task<List<Fornecedor>> GetAllFornecedor(int id)
        {
            return await _fornecedorService.GetAllFornecedor(id);
        }


        public async Task<List<Fornecedor>> GetForncedor(string val, int empresaId)
        {
            return await _fornecedorService.GetForncedor(val, empresaId);
        }
    }
}




