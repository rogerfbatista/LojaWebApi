using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class EmpresaClienteService : ServiceBase<EmpresaCliente>, IEmpresaClienteService
    {
        private readonly IEmpresaClienteRepository _empresaClienteRepository;

        public EmpresaClienteService(IEmpresaClienteRepository empresaClienteRepository):base(empresaClienteRepository)
        {
            _empresaClienteRepository = empresaClienteRepository;
        }
    }

}