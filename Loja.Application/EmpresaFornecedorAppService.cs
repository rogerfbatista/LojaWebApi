using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class EmpresaFornecedorAppService : AppServiceBase<EmpresaFornecedor>, IEmpresaFornecedorAppService
    {
        private readonly IEmpresaFornecedorService _empresaFornecedorService;

        public EmpresaFornecedorAppService(IEmpresaFornecedorService empresaFornecedorService):base(empresaFornecedorService)
        {
            _empresaFornecedorService = empresaFornecedorService;
        }
    }

    
}
