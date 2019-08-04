using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class ProdutoFormasDePagamento
    {
        public ProdutoFormasDePagamento()
        {
            this.ProdutoClienteSaidas = new List<ProdutoClienteSaida>();
        }

        public int ProdutoFormasDePagamentoId { get; set; }
        public string NomeFormaPagamento { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual ICollection<ProdutoClienteSaida> ProdutoClienteSaidas { get; set; }
    }
}
