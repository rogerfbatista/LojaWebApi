using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class MenuTipoAppService : AppServiceBase<MenuTipo>, IMenuTipoAppService
    {
        private readonly IMenuTipoService _menuTipoService;

        public MenuTipoAppService(IMenuTipoService menuTipoService):base(menuTipoService)
        {
            _menuTipoService = menuTipoService;
        }
    }
   
}
