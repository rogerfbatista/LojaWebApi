
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interfaces.Services
{
    public interface IServicoUsuarioPerfilService : IServiceBase<ServicoUsuarioPerfil>
    {

        Task<List<ServicoUsuarioPerfil>> GetServicoUsarioPerilList(Func<ServicoUsuarioPerfil, bool> predicate);
    }
}
