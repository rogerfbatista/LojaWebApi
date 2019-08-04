using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class EmpresaContato
    {
        public int EmpresaContatoId { get; set; }
        public Nullable<int> EmpresaId { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
