using System.Linq;
using System.Threading.Tasks;
using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class MenuAppService : AppServiceBase<Menu>, IMenuAppService
    {
        private readonly IMenuService _menuService;
        private readonly IUsuarioPerfilMenuService _usuarioPerfilMenuService;

        public MenuAppService(IMenuService menuService, IUsuarioPerfilMenuService usuarioPerfilMenuService)
            : base(menuService)
        {
            _menuService = menuService;
            _usuarioPerfilMenuService = usuarioPerfilMenuService;
        }

        public new async Task Update(Menu obj)
        {

            var listAdd = obj.UsuarioPerfilMenus.ToList();
            var listRemove = await _usuarioPerfilMenuService.GetAll(menu => menu.MenuId == obj.MenuId);


            if (listRemove.Any())
            {
                foreach (UsuarioPerfilMenu menu in listRemove)
                {
                    await _usuarioPerfilMenuService.RemovePhysical(menu);
                }

            }

            if (listAdd.Any())
            {
                foreach (UsuarioPerfilMenu perfilMenu in listAdd)
                {
                    perfilMenu.SetObjNull();

                    await _usuarioPerfilMenuService.Add(perfilMenu);
                }
            }

            obj.SetUsuarioPerfilMenuNull();
            await _menuService.Update(obj);
        }

        public new async Task RemoveLogic(int id, Menu obj)
        {
            var menu = await _menuService.GetById(id);

            var count = menu.UsuarioPerfilMenus.Count;

            for (var i = 0; i < count; i++)
            {
                var perfil = (UsuarioPerfilMenu) menu.UsuarioPerfilMenus.ToList()[0];

                await _usuarioPerfilMenuService.RemovePhysical(perfil);
            }
          
           
            await _menuService.RemovePhysical(menu);
        }
    }

}
