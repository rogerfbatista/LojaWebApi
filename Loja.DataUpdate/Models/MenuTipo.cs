using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class MenuTipo
    {
        public MenuTipo()
        {
            this.Menus = new List<Menu>();
        }

        public int MenuTipoId { get; set; }
        public string NomeMenuTipo { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
