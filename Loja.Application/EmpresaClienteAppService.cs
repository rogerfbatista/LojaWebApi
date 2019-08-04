using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class EmpresaClienteAppService : AppServiceBase<EmpresaCliente>, IEmpresaClienteAppService
    {
        private readonly IEmpresaClienteService _empresaClienteService;

        public EmpresaClienteAppService(IEmpresaClienteService empresaClienteService)
            : base(empresaClienteService)
        {
            _empresaClienteService = empresaClienteService;
        }
    }

}