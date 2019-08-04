using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public class MenuTipo
    {
        protected MenuTipo()
        {
            Menu = new List<Menu>();
        }

        public MenuTipo(int menuTipoId, string nomeMenuTipo, bool? ativo, ICollection<Menu> menu)
        {
            MenuTipoId = menuTipoId;
            NomeMenuTipo = nomeMenuTipo;
            Ativo = ativo;
            Menu = menu;
        }

        public MenuTipo(string nomeMenuTipo, bool? ativo = true, int menuTipoId = 0)
        {
            MenuTipoId = menuTipoId;
            NomeMenuTipo = nomeMenuTipo;
            Ativo = ativo;

        }

        [DataMember(Name = "MenuTipoId")]
        public int MenuTipoId { get; private set; }
        [DataMember(Name = "NomeMenuTipo")]
        public string NomeMenuTipo { get; private set; }
        [DataMember(Name = "Ativo")]
        public bool? Ativo { get; private set; }
        [DataMember(Name = "Menu")]
        public virtual ICollection<Menu> Menu { get; private set; }
    }
}
