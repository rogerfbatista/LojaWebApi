using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class FornecedorContatoAppService : AppServiceBase<FornecedorContato>, IFornecedorContatoAppService
    {
        private readonly IFornecedorContatoService _fornecedorContatoService;

        public FornecedorContatoAppService(IFornecedorContatoService fornecedorContatoService):base(fornecedorContatoService)
        {
            _fornecedorContatoService = fornecedorContatoService;
        }
    }
    
}
