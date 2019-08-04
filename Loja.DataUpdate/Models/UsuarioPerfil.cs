using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class UsuarioPerfil
    {
        public UsuarioPerfil()
        {
            this.ServicoUsuarioPerfils = new List<ServicoUsuarioPerfil>();
            this.Usuarios = new List<Usuario>();
            this.UsuarioPerfilMenus = new List<UsuarioPerfilMenu>();
        }

        public int UsuarioPerfilId { get; set; }
        public string NomeUsuarioPerfil { get; set; }
        public byte[] ImagemUsuarioPerfil { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual ICollection<ServicoUsuarioPerfil> ServicoUsuarioPerfils { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<UsuarioPerfilMenu> UsuarioPerfilMenus { get; set; }
    }
}
