using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
         Task<Usuario> Authenticantion(string email, string senha);

    }

}
