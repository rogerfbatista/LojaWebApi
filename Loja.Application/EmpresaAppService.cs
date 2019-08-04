using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class EmpresaAppService : AppServiceBase<Empresa>, IEmpresaAppService
    {
        private readonly IEmpresaContatoService _empresaContatoService;
        private readonly IEmpresaService _empresaService;

        public EmpresaAppService(IEmpresaService empresaService, IEmpresaContatoService empresaContatoService)
            : base(empresaService)
        {
            _empresaService = empresaService;
            _empresaContatoService = empresaContatoService;
        }

        public new async Task Update(Empresa obj)
        {
            var listContatoAdd = new List<EmpresaContato>();
            var listContatoUpdate = new List<EmpresaContato>();

            foreach (var contato in obj.EmpresaContatos)
            {
                if (contato.EmpresaContatoId == 0)
                    listContatoAdd.Add(contato);


                if (contato.Ativo == false)
                    listContatoUpdate.Add(contato);
            }
            await _empresaService.Update(obj);

            //add empresaContato
            foreach (var empresaContato in listContatoAdd)
            {
                await _empresaContatoService.Add(empresaContato);
            }

        
            foreach (var empresaContato in listContatoUpdate)
            {
                await _empresaContatoService.Update(empresaContato);
            }
        }

        public new async Task RemoveLogic(int id, Empresa obj)
        {

            var empresa = await _empresaService.GetById(id);

            empresa.Ativo = false;

            foreach (var contato in empresa.EmpresaContatos)
            {
                contato.Empresa = null;
            }

            await _empresaService.RemoveLogic(id, empresa);

            foreach (var contato in empresa.EmpresaContatos)
            {
                contato.Ativo = false;
                contato.Empresa = null;

                await _empresaContatoService.RemoveLogic(id, contato);

            }


        }
    }
}