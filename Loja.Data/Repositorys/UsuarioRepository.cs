using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Loja.Common.Validation;
using Loja.Data.Contexto;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;

namespace Loja.Data.Repositorys
{

    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {


        public async Task<Usuario> Authenticantion(string email, string senha)
        {
            using (var loja = new LojaContext())
            {


                loja.Configuration.AutoDetectChangesEnabled = false;
                senha = PasswordAssertionConcern.Encrypt(senha);


                return await loja.Set<Usuario>()
                    .Where(
                        user =>
                            user.Ativo == true && user.Email == email &&
                            user.Senha == senha)
                    .Include(usuario => usuario.UsuarioPerfil)
                    .Include(usuario => usuario.Empresa).FirstOrDefaultAsync();
            }

        }
    }


}
