using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public class UsuarioPerfil
    {
        protected UsuarioPerfil()
        {
            Usuarios = new List<Usuario>();
            UsuarioPerfilMenus = new List<UsuarioPerfilMenu>();
            ServicoUsuarioPerfil = new List<ServicoUsuarioPerfil>();
        }

        public UsuarioPerfil(int usuarioPerfilId, string nomeUsuarioPerfil, byte[] imagemUsuarioPerfil, bool? ativo,
                             ICollection<Usuario> usuarios, ICollection<UsuarioPerfilMenu> usuarioPerfilMenus)
        {
            UsuarioPerfilId = usuarioPerfilId;
            NomeUsuarioPerfil = nomeUsuarioPerfil;
            ImagemUsuarioPerfil = imagemUsuarioPerfil;
            Ativo = ativo;
            Usuarios = usuarios;
            UsuarioPerfilMenus = usuarioPerfilMenus;
        }

        public UsuarioPerfil(string nomeUsuarioPerfil, byte[] imagemUsuarioPerfil = null, bool? ativo = true, int usuarioPerfilId = 0)
        {
            UsuarioPerfilId = usuarioPerfilId;
            NomeUsuarioPerfil = nomeUsuarioPerfil;
            ImagemUsuarioPerfil = imagemUsuarioPerfil;
            Ativo = ativo;

        }

        [DataMember(Name = "UsuarioPerfilId")]
        public int UsuarioPerfilId { get; private set; }
        [DataMember(Name = "NomeUsuarioPerfil")]
        public string NomeUsuarioPerfil { get; private set; }
        [DataMember(Name = "ImagemUsuarioPerfil")]
        public byte[] ImagemUsuarioPerfil { get; private set; }
        [DataMember(Name = "Ativo")]
        public bool? Ativo { get; private set; }
        [DataMember(Name = "Usuarios")]
        public virtual ICollection<Usuario> Usuarios { get; private set; }
        [DataMember(Name = "UsuarioPerfilMenus")]
        public virtual ICollection<UsuarioPerfilMenu> UsuarioPerfilMenus { get; private set; }
        [DataMember(Name = "ServicoUsuarioPerfil")]
        public virtual ICollection<ServicoUsuarioPerfil> ServicoUsuarioPerfil { get; private set; }


        public void SetObjNull()
        {
            Usuarios = null;
            UsuarioPerfilMenus = null;
            ServicoUsuarioPerfil = null;
        }

        public void SetAtivoFalse()
        {
            Ativo = false;
        }
    }
}
