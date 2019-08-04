using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Application.Interfaces
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        Task<Usuario> Authenticantion(string email, string senha);

    }

}
