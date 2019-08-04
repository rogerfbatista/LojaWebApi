using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class FornecedorContatoService : ServiceBase<FornecedorContato>, IFornecedorContatoService
    {
        private readonly IFornecedorContatoRepository _fornecedorContatoRepository;

        public FornecedorContatoService(IFornecedorContatoRepository fornecedorContatoRepository):
            base(fornecedorContatoRepository)
        {
            _fornecedorContatoRepository = fornecedorContatoRepository;
        }
    }
}
