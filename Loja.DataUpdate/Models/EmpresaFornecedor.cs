using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class EmpresaFornecedor
    {
        public int EmpresaFornecedorId { get; set; }
        public Nullable<int> FornecedorId { get; set; }
        public Nullable<int> EmpresaId { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
