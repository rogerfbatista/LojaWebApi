using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interfaces.Repositorys
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario> Authenticantion( string email, string senha);

    }

}
