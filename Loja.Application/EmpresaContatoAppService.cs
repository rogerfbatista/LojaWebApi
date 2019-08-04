using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class EmpresaContatoAppService : AppServiceBase<EmpresaContato>, IEmpresaContatoAppService
    {
        private readonly IEmpresaContatoService _empresaContatoService;

        public EmpresaContatoAppService(IEmpresaContatoService empresaContatoService)
            : base(empresaContatoService)
        {
            _empresaContatoService = empresaContatoService;
        }
    }
}

