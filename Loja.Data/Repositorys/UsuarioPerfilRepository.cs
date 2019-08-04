using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Loja.Data.Contexto;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;

namespace Loja.Data.Repositorys
{
    public class UsuarioPerfilRepository : RepositoryBase<UsuarioPerfil>, IUsuarioPerfilRepository
    {
        public new  async Task<UsuarioPerfil> GetById(int id)
        {
            using (DbContext = new LojaContext())
            {
            return  await  DbContext.Set<UsuarioPerfil>().Where(perfil => perfil.UsuarioPerfilId == id)
                    .Include(perfil => perfil.Usuarios ).Include(perfil => perfil.ServicoUsuarioPerfil).FirstOrDefaultAsync();
            }
        }
    }

    
}
