
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class ServicoUsuarioPerfilService : ServiceBase<ServicoUsuarioPerfil>, IServicoUsuarioPerfilService
    {
        private readonly IServicoUsuarioPerfilRepository _servicoUsuarioPerfilRepository;

        public ServicoUsuarioPerfilService(IServicoUsuarioPerfilRepository servicoUsuarioPerfilRepository) :
            base(servicoUsuarioPerfilRepository)
        {
            _servicoUsuarioPerfilRepository = servicoUsuarioPerfilRepository;
        }

        public IServicoUsuarioPerfilRepository ServicoUsuarioPerfilRepository
        {
            get { return _servicoUsuarioPerfilRepository; }
        }

        public Task<List<ServicoUsuarioPerfil>> GetServicoUsarioPerilList(Func<ServicoUsuarioPerfil, bool> predicate)
        {
            return _servicoUsuarioPerfilRepository.GetServicoUsarioPerilList(predicate);
        }
    }
}
