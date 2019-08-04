using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class ServicoUsuarioPerfil
    {
        public int ServicoUsuarioPerfilId { get; set; }
        public Nullable<int> ServicoId { get; set; }
        public Nullable<int> UsuarioPerfilId { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual Servico Servico { get; set; }
        public virtual UsuarioPerfil UsuarioPerfil { get; set; }
    }
}
