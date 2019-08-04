using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Loja.Application.Interfaces;
using Loja.Common;
using Loja.Common.Resources;
using Loja.Common.Validation;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{

    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
            : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<Usuario> Authenticantion(string email, string senha)
        {
            

            return await _usuarioService.Authenticantion(email, senha);
        }

        public new async Task Add(Usuario obj)
        {
            var user = await _usuarioService.GetAll(usuario => usuario.EmpresaId == obj.EmpresaId
                                   && String.Equals(usuario.Email, obj.Email, StringComparison.OrdinalIgnoreCase));

            AssertionConcern.AssertArgumentFalse(user.Count > 0, Errors.DuplicateEmail);

            var senha = obj.Senha;
            obj.SetSenha(obj.Senha, obj.Senha);
            await _usuarioService.Add(obj);

            var corpo = new StringBuilder();
            corpo.AppendFormat("Email é {0} Senha{1}", obj.Email, senha);

            await new EmailManager().EnviarEmail("Usuario Sonic TI", corpo, new List<string>()
             {
                 obj.Email
             }, new List<Attachment>());

        }

        public new async Task Update(Usuario obj)
        {

           
            obj.SetSenha(obj.Senha, obj.Senha);
            await _usuarioService.Update(obj);

            var senha = PasswordAssertionConcern.Decrypt(obj.Senha);

            var corpo = new StringBuilder();
            corpo.AppendFormat("Seu Usuario foi alterado Email é {0} Senha{1}", obj.Email, senha);

            await new EmailManager().EnviarEmail("Usuario Sonic TI", corpo, new List<string>()
            {
                obj.Email
            }, new List<Attachment>());

        }

        public new async Task RemoveLogic(int id, Usuario obj)
        {
            var user = await _usuarioService.GetById(id);
            AssertionConcern.AssertArgumentFalse(user == null, Errors.UserNotFound);

            user.Ativo = false;

            await _usuarioService.RemoveLogic(id, user);

        }
    }


}
