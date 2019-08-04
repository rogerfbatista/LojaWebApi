using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class UsuarioPerfilService : ServiceBase<UsuarioPerfil>, IUsuarioPerfilService
    {
        private readonly IUsuarioPerfilRepository _usuarioPerfilRepository;

        public UsuarioPerfilService(IUsuarioPerfilRepository usuarioPerfilRepository):base(usuarioPerfilRepository)
        {
            _usuarioPerfilRepository = usuarioPerfilRepository;
        }
    }

    
}
