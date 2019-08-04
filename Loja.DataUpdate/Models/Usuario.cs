using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class Usuario
    {
        public int UsuarioId { get; set; }
        public Nullable<int> UsuarioPerfilId { get; set; }
        public Nullable<int> EmpresaId { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public byte[] ImagemUsuario { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual UsuarioPerfil UsuarioPerfil { get; set; }
    }
}
