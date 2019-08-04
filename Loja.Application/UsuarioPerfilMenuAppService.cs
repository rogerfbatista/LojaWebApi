using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class UsuarioPerfilMenuAppService : AppServiceBase<UsuarioPerfilMenu>, IUsuarioPerfilMenuAppService
    {
        private readonly IUsuarioPerfilMenuService _usuarioPerfilMenuService;

        public UsuarioPerfilMenuAppService(IUsuarioPerfilMenuService usuarioPerfilMenuService)
            :base(usuarioPerfilMenuService)
        {
            _usuarioPerfilMenuService = usuarioPerfilMenuService;
        }


        
    }


}
