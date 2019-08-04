using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class MenuService : ServiceBase<Menu>, IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository):base(menuRepository)
        {
            _menuRepository = menuRepository;
        }
    }

}
