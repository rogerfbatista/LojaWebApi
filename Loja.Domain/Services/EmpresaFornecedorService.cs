using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class EmpresaFornecedorService : ServiceBase<EmpresaFornecedor>, IEmpresaFornecedorService
    {
        private readonly IEmpresaFornecedorRepository _empresaFornecedorRepository;

        public EmpresaFornecedorService(IEmpresaFornecedorRepository empresaFornecedorRepository):base(empresaFornecedorRepository)
        {
            _empresaFornecedorRepository = empresaFornecedorRepository;
        }
    }

    
}
