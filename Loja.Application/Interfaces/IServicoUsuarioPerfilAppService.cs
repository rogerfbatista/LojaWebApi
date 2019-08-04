using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Application.Interfaces
{
    public interface IServicoUsuarioPerfilAppService : IAppServiceBase<ServicoUsuarioPerfil>
    {
        Task<List<ServicoUsuarioPerfil>> GetServicoUsarioPerilList(Func<ServicoUsuarioPerfil, bool> predicate);
    }
}
