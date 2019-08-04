using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class ProdutoFornecedorEntrada
    {
        public int ProdutoEntradaId { get; set; }
        public Nullable<int> ProdutoId { get; set; }
        public Nullable<int> FornecedorId { get; set; }
        public Nullable<int> EmpresaId { get; set; }
        public string NotaFiscalId { get; set; }
        public Nullable<int> QuantidadeEntrada { get; set; }
        public Nullable<decimal> ValorUnitario { get; set; }
        public Nullable<System.DateTime> DataEntrada { get; set; }
        public Nullable<System.DateTime> DataEmissao { get; set; }
        public Nullable<System.DateTime> DataVencimento { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
