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
    public class ServicoUsuarioPerfilRepository : RepositoryBase<ServicoUsuarioPerfil>, IServicoUsuarioPerfilRepository
    {
        
        public async Task<List<ServicoUsuarioPerfil>> GetServicoUsarioPerilList(Func<ServicoUsuarioPerfil, bool> predicate)
        {
            using (DbContext = new LojaContext())
            {


                DbContext.Configuration.AutoDetectChangesEnabled = false;
                return await Task.Factory.StartNew(() => DbContext.Set<ServicoUsuarioPerfil>().
                    Include(perfil => perfil.UsuarioPerfil).Include(perfil => perfil.Servico).Where(predicate).ToList());
            }
        }
    }
}
