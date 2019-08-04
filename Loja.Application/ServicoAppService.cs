
using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class ServicoAppService : AppServiceBase<Servico>, IServicoAppService
    {
        private readonly IServicoService _servicoService;

        public ServicoAppService(IServicoService servicoService):base(servicoService)
        {
            _servicoService = servicoService;
        }

        public IServicoService ServicoService
        {
            get { return _servicoService; }
        }
    }
}
