using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class MenuTipoService : ServiceBase<MenuTipo>, IMenuTipoService
    {
        private readonly IMenuTipoRepository _menuTipoRepository;

        public MenuTipoService(IMenuTipoRepository menuTipoRepository):base(menuTipoRepository)
        {
            _menuTipoRepository = menuTipoRepository;
        }
    }
   
}
