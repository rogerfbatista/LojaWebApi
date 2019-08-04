using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public class UsuarioPerfilMenu
    {

        protected UsuarioPerfilMenu()
        {

        }

        public UsuarioPerfilMenu(int usuarioPerfilMenuId, int? menuId, int? usuarioPerfilId, bool? ativo,
                                Menu menu, UsuarioPerfil usuarioPerfil)
        {
            UsuarioPerfilMenuId = usuarioPerfilMenuId;
            MenuId = menuId;
            UsuarioPerfilId = usuarioPerfilId;
            Ativo = ativo;
            Menu = menu;
            UsuarioPerfil = usuarioPerfil;
        }

        public UsuarioPerfilMenu(int usuarioPerfilMenuId, int? menuId, int? usuarioPerfilId, bool? ativo)
        {
            UsuarioPerfilMenuId = usuarioPerfilMenuId;
            MenuId = menuId;
            UsuarioPerfilId = usuarioPerfilId;
            Ativo = ativo;

        }


        [DataMember(Name = "UsuarioPerfilMenuId")]
        public int UsuarioPerfilMenuId { get; private set; }
        [DataMember(Name = "MenuId")]
        public int? MenuId { get; private set; }
        [DataMember(Name = "UsuarioPerfilId")]
        public int? UsuarioPerfilId { get; private set; }
        [DataMember(Name = "Ativo")]
        public bool? Ativo { get; private set; }
        [DataMember(Name = "Menu")]
        public virtual Menu Menu { get; private set; }
        [DataMember(Name = "UsuarioPerfil")]
        public virtual UsuarioPerfil UsuarioPerfil { get; private set; }


        public void SetObjNull()
        {
            Menu = null;
            UsuarioPerfil = null;
            UsuarioPerfilMenuId = 0;
        }

        public void SetAtivoFalse()
        {
            Ativo = false;
        }


    }
}
