using System.Linq;
using System.Threading.Tasks;
using Loja.Application.Interfaces;
using Loja.Common.Validation;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class UsuarioPerfilAppService : AppServiceBase<UsuarioPerfil>, IUsuarioPerfilAppService
    {
        private readonly IUsuarioPerfilService _usuarioPerfilService;
        private readonly IServicoUsuarioPerfilService _servicoUsuarioPerfilService;

        public UsuarioPerfilAppService(IUsuarioPerfilService usuarioPerfilService, IServicoUsuarioPerfilService servicoUsuarioPerfilService)
            : base(usuarioPerfilService)
        {
            _usuarioPerfilService = usuarioPerfilService;
            _servicoUsuarioPerfilService = servicoUsuarioPerfilService;
        }

        public new async Task RemoveLogic(int id, UsuarioPerfil obj)
        {
            var usuarioPeril = await _usuarioPerfilService.GetById(id);

            AssertionConcern.AssertArgumentFalse(usuarioPeril.Usuarios.Count > 0, "Não é possivel excluir existem Usuarios Cadastrados com esse Perfil");
            AssertionConcern.AssertArgumentFalse(usuarioPeril.ServicoUsuarioPerfil.Count > 0, "Não é possivel excluir existem Servicos Cadastrados com esse Perfil");

            usuarioPeril.SetAtivoFalse();

           
            await _usuarioPerfilService.RemoveLogic(id, usuarioPeril);

        }

        public new async Task Add(UsuarioPerfil obj)
        {
            var listExist =
                await _usuarioPerfilService.GetAll(perfil => perfil.NomeUsuarioPerfil == obj.NomeUsuarioPerfil && perfil.Ativo == true);

            AssertionConcern.AssertArgumentFalse(listExist.Count > 0, "Perfil ja Cadastrado");

            await _usuarioPerfilService.Add(obj);

        }

        public new async Task Update(UsuarioPerfil obj)
        {

            var listAdd = obj.ServicoUsuarioPerfil.ToList();
            var listRemove = await _servicoUsuarioPerfilService.GetAll(perfil => perfil.UsuarioPerfilId == obj.UsuarioPerfilId);


            if (listRemove.Any())
            {
                foreach (ServicoUsuarioPerfil perfil in listRemove)
                {
                    await _servicoUsuarioPerfilService.RemovePhysical(perfil);
                }

            }

            if (listAdd.Any())
            {
                foreach (ServicoUsuarioPerfil perfil in listAdd)
                {
                    perfil.SetObjNull();

                    await _servicoUsuarioPerfilService.Add(perfil);
                }
            }

            obj.SetObjNull();
            await _usuarioPerfilService.Update(obj);
        }
    }


}
