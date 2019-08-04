using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class EmpresaCliente
    {
        public int EmpresaClienteId { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public Nullable<int> EmpresaId { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
