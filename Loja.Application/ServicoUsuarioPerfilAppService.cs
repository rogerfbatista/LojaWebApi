using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class ServicoUsuarioPerfilAppService : AppServiceBase<ServicoUsuarioPerfil>, IServicoUsuarioPerfilAppService
    {
        private readonly IServicoUsuarioPerfilService _servicoUsuarioPerfilService;

        public ServicoUsuarioPerfilAppService(IServicoUsuarioPerfilService servicoUsuarioPerfilService)
            : base(servicoUsuarioPerfilService)
        {
            _servicoUsuarioPerfilService = servicoUsuarioPerfilService;
        }

        public async Task<List<ServicoUsuarioPerfil>> GetServicoUsarioPerilList(Func<ServicoUsuarioPerfil, bool> predicate)
        {
            return await _servicoUsuarioPerfilService.GetServicoUsarioPerilList(predicate);
        }

        public IServicoUsuarioPerfilService ServicoUsuarioPerfilService
        {
            get { return _servicoUsuarioPerfilService; }
        }


    }
}
