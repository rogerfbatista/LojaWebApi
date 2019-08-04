using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class FornecedorContato
    {
        public int FornecedorContatoId { get; set; }
        public Nullable<int> FornecedorId { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
