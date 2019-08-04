using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;

namespace Loja.Domain.Interfaces.Repositorys
{
    public interface IServicoUsuarioPerfilRepository:IRepositoryBase<ServicoUsuarioPerfil>
    {

        Task<List<ServicoUsuarioPerfil>> GetServicoUsarioPerilList(Func<ServicoUsuarioPerfil, bool> predicate);
    }
}
