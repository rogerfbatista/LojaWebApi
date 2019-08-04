
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class ServicoService : ServiceBase<Servico>, IServicoService
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoService(IServicoRepository servicoRepository)
            : base(servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public IServicoRepository ServicoRepository
        {
            get { return _servicoRepository; }
        }
    }
}
