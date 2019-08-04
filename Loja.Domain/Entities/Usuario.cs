using System;
using System.Runtime.Serialization;
using Loja.Common.Validation;
using Loja.Common.Resources;

namespace Loja.Domain.Entities
{
    [DataContract]
    public class Usuario
    {
        private DateTime? _dataCadastro;

        protected Usuario()
        {

        }

        public Usuario(int usuarioId, int? usuarioPerfilId, int? empresaId, string nomeUsuario, string email,
            DateTime? dataCadastro, byte[] imagemUsuario, bool? ativo, Empresa empresa, UsuarioPerfil usuarioPerfil)
        {


            UsuarioId = usuarioId;
            UsuarioPerfilId = usuarioPerfilId;
            EmpresaId = empresaId;
            NomeUsuario = nomeUsuario;
            Email = email;

            DataCadastro = dataCadastro;
            ImagemUsuario = imagemUsuario;
            Ativo = ativo;
            Empresa = empresa;
            UsuarioPerfil = usuarioPerfil;
        }

        public Usuario(int? usuarioPerfilId, int? empresaId, string nomeUsuario, string email,
           DateTime? dataCadastro, byte[] imagemUsuario, bool? ativo = true, int usuarioId = 0)
        {
            AssertionConcern.AssertArgumentNotEmpty(nomeUsuario, Errors.CampoVazio);

            UsuarioId = usuarioId;
            UsuarioPerfilId = usuarioPerfilId;
            EmpresaId = empresaId;
            NomeUsuario = nomeUsuario;
            Email = email;

            DataCadastro = dataCadastro;
            ImagemUsuario = imagemUsuario;
            Ativo = ativo;

        }

        public void SetSenha(string senha, string confirmarSenha)
        {
            AssertionConcern.AssertArgumentNotNull(senha, Errors.InvalidUserPassword);
            AssertionConcern.AssertArgumentNotNull(confirmarSenha, Errors.InvalidUserPassword);
            AssertionConcern.AssertArgumentEquals(senha, confirmarSenha, Errors.PasswordDoesNotMatch);
            Senha = PasswordAssertionConcern.Encrypt(senha);


        }

        public string SetSenha(string senha)
        {
            AssertionConcern.AssertArgumentNotNull(senha, Errors.InvalidUserPassword);
            return PasswordAssertionConcern.Encrypt(senha);
        }

        [DataMember(Name = "UsuarioId")]
        public int UsuarioId { get; private set; }
        [DataMember(Name = "UsuarioPerfilId")]
        public int? UsuarioPerfilId { get; private set; }
        [DataMember(Name = "EmpresaId")]
        public int? EmpresaId { get; private set; }
        [DataMember(Name = "NomeUsuario")]
        public string NomeUsuario { get; private set; }
        [DataMember(Name = "Email")]
        public string Email { get; private set; }
        [DataMember(Name = "Senha")]
        public string Senha { get; private set; }

        [DataMember(Name = "DataCadastro")]
        public DateTime? DataCadastro
        {
            get { return _dataCadastro; }
            set {
                _dataCadastro = value ?? DateTime.Now;
            }
        }

        [DataMember(Name = "ImagemUsuario")]
        public byte[] ImagemUsuario { get; private set; }
        [DataMember(Name = "Ativo")]
        public bool? Ativo { get;  set; }
        [DataMember(Name = "Empresa")]
        public virtual Empresa Empresa { get; private set; }
        [DataMember(Name = "UsuarioPerfil")]
        public virtual UsuarioPerfil UsuarioPerfil { get; private set; }
    }
}
