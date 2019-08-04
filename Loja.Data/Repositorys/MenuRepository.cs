using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Loja.Data.Contexto;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;

namespace Loja.Data.Repositorys
{
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public new async Task<List<Menu>> GetAll(Func<Menu, bool> predicate)
        {
            using (var loja = new LojaContext())
            {
                var query = loja.Menus.Where(predicate).ToList();

                return await Task.Factory.StartNew(() => (query.Select(m =>
                    new Menu(m.MenuId, m.MenuTipoId, m.MenuIdFk, m.EmpresaId, m.NomeMenu, m.Link, m.Ordem, m.ImagemMenu,
                        m.Ativo))).ToList());

            }
        }

        public new async Task<Menu> GetById(int id)
        {
            using (var loja = new LojaContext())
            {
                

                return
                    await
                        loja.Menus.Include(menu => menu.UsuarioPerfilMenus)
                            .FirstOrDefaultAsync(menu => menu.MenuId == id);

            }
        }
    }

}
