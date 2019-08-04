using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class EmpresaContatoService : ServiceBase<EmpresaContato>, IEmpresaContatoService
    {
        private readonly IEmpresaContatoRepository _empresaContatoRepository;

        public EmpresaContatoService(IEmpresaContatoRepository empresaContatoRepository):base(empresaContatoRepository)
        {
            _empresaContatoRepository = empresaContatoRepository;
        }
    }
}

