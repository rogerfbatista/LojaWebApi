
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
    public class UsuarioPerfilMenuRepository : RepositoryBase<UsuarioPerfilMenu>, IUsuarioPerfilMenuRepository
    {
        private readonly LojaContext _lojaContext;

        public UsuarioPerfilMenuRepository(LojaContext lojaContext)
        {
            _lojaContext = lojaContext;
        }

        /// <summary>
        /// Sobre escrever o methodo retornar o incluid
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public new async Task<List<UsuarioPerfilMenu>> GetAll(Func<UsuarioPerfilMenu, bool> predicate)
        {


            var query = await Task.Factory.StartNew(() => _lojaContext.Set<UsuarioPerfilMenu>().
                Include(menu => menu.Menu)
                .Where(predicate).OrderBy(menu => menu.Menu.Ordem).ToList());

            return query.FindAll(delegate(UsuarioPerfilMenu menu)
            {

                var listRemove = menu.Menu
                    .MenuCollection
                    .Where(m => !m.UsuarioPerfilMenus
                        .Exists(perfilMenu => perfilMenu.UsuarioPerfilId == menu.UsuarioPerfilId))
                        .ToList();

                foreach (var list in listRemove)
                {
                    menu.Menu.MenuCollection.Remove(list);
                }

                return true;
            });
        }


    }
}



