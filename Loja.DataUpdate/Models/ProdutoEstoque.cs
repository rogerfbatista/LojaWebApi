using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class ProdutoEstoque
    {
        public int ProdutoEstoqueId { get; set; }
        public Nullable<int> EmpresaId { get; set; }
        public Nullable<int> ProdutoId { get; set; }
        public Nullable<int> QuantidadeEstoque { get; set; }
        public Nullable<decimal> ValorVenda { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
