using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class UsuarioPerfilMenu
    {
        public int UsuarioPerfilMenuId { get; set; }
        public Nullable<int> MenuId { get; set; }
        public Nullable<int> UsuarioPerfilId { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual UsuarioPerfil UsuarioPerfil { get; set; }
    }
}
