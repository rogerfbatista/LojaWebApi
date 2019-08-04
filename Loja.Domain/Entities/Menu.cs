using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public class Menu
    {
        protected Menu()
        {
            MenuCollection = new List<Menu>();
            UsuarioPerfilMenus = new List<UsuarioPerfilMenu>();
        }

        public Menu(int menuId, int? menuTipoId, int? menuIdFk, int? empresaId, string nomeMenu, string link, int? ordem,
                     byte[] imagemMenu, bool? ativo, Empresa empresa, List<Menu> menuCollection, Menu menuClassMenu,
                     MenuTipo menuTipo, List<UsuarioPerfilMenu> usuarioPerfilMenu)
        {
            MenuId = menuId;
            MenuTipoId = menuTipoId;
            MenuIdFk = menuIdFk;
            EmpresaId = empresaId;
            NomeMenu = nomeMenu;
            Link = link;
            Ordem = ordem;
            ImagemMenu = imagemMenu;
            Ativo = ativo;
            Empresa = empresa;
            MenuCollection = menuCollection;
            MenuClassMenu = menuClassMenu;
            MenuTipo = menuTipo;
            UsuarioPerfilMenus = usuarioPerfilMenu;
        }

        public Menu(int menuId, int? menuTipoId, int? menuIdFk, int? empresaId, string nomeMenu, string link, int? ordem,
                    byte[] imagemMenu, bool? ativo)
        {
            MenuId = menuId;
            MenuTipoId = menuTipoId;
            MenuIdFk = menuIdFk;
            EmpresaId = empresaId;
            NomeMenu = nomeMenu;
            Link = link;
            Ordem = Ordem;
            ImagemMenu = imagemMenu;
            Ativo = ativo;
            Ordem = ordem;

        }

        [DataMember(Name = "MenuId")]
        public int MenuId { get; private set; }
        [DataMember(Name = "MenuTipoId")]
        public int? MenuTipoId { get; private set; }
        [DataMember(Name = "MenuIdFk")]
        public int? MenuIdFk { get; private set; }
        [DataMember(Name = "EmpresaId")]
        public int? EmpresaId { get; private set; }
        [DataMember(Name = "NomeMenu")]
        public string NomeMenu { get; private set; }
        [DataMember(Name = "Link")]
        public string Link { get; private set; }
        [DataMember(Name = "Ordem")]
        public int? Ordem { get; private set; }
        [DataMember(Name = "ImagemMenu")]
        public byte[] ImagemMenu { get; private set; }
        [DataMember(Name = "Ativo")]
        public bool? Ativo { get; private set; }
        [DataMember(Name = "Empresa")]
        public virtual Empresa Empresa { get; private set; }
        [DataMember(Name = "MenuCollection")]
        public virtual List<Menu> MenuCollection { get; private set; }
        [DataMember(Name = "MenuClassMenu")]
        public virtual Menu MenuClassMenu { get; private set; }
        [DataMember(Name = "MenuTipo")]
        public virtual MenuTipo MenuTipo { get; private set; }
        [DataMember(Name = "UsuarioPerfilMenus")]
        public virtual List<UsuarioPerfilMenu> UsuarioPerfilMenus { get; private set; }

        public void SetUsuarioPerfilMenuNull()
        {
            UsuarioPerfilMenus = null;
        }

        public void SetAtivoFalse()
        {
            Ativo = false;
        }
    }
}
