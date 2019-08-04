using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class ProdutoClienteSaida
    {
        public ProdutoClienteSaida()
        {
            this.ProdutoClienteSaidaItems = new List<ProdutoClienteSaidaItem>();
        }

        public int ProdutoClienteSaidaId { get; set; }
        public Nullable<int> EmpresaId { get; set; }
        public Nullable<int> ProdutoFormasDePagamentoId { get; set; }
        public Nullable<decimal> ValorTotal { get; set; }
        public Nullable<System.DateTime> DataVenda { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<ProdutoClienteSaidaItem> ProdutoClienteSaidaItems { get; set; }
        public virtual ProdutoFormasDePagamento ProdutoFormasDePagamento { get; set; }
    }
}
