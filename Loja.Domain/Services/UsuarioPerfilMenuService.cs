using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class UsuarioPerfilMenuService : ServiceBase<UsuarioPerfilMenu>, IUsuarioPerfilMenuService
    {

        private readonly IUsuarioPerfilMenuRepository _usuarioPerfilMenuRepository;

        public UsuarioPerfilMenuService(IUsuarioPerfilMenuRepository usuarioPerfilMenuRepository):
            base(usuarioPerfilMenuRepository)
        {
            _usuarioPerfilMenuRepository = usuarioPerfilMenuRepository;
        }

        
    }


}
