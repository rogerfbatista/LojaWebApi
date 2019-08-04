using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class Menu
    {
        public Menu()
        {
            this.Menu1 = new List<Menu>();
            this.UsuarioPerfilMenus = new List<UsuarioPerfilMenu>();
        }

        public int MenuId { get; set; }
        public Nullable<int> MenuTipoId { get; set; }
        public Nullable<int> MenuIdFk { get; set; }
        public Nullable<int> EmpresaId { get; set; }
        public string NomeMenu { get; set; }
        public string Link { get; set; }
        public Nullable<int> Ordem { get; set; }
        public byte[] ImagemMenu { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Menu> Menu1 { get; set; }
        public virtual Menu Menu2 { get; set; }
        public virtual MenuTipo MenuTipo { get; set; }
        public virtual ICollection<UsuarioPerfilMenu> UsuarioPerfilMenus { get; set; }
    }
}
