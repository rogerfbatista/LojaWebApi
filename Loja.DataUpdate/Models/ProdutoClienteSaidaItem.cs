using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class ProdutoClienteSaidaItem
    {
        public int ProdutoClienteSaidaItemId { get; set; }
        public Nullable<int> ProdutoClienteSaidaId { get; set; }
        public Nullable<int> ProdutoId { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public Nullable<int> QuantidadeSaida { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual ProdutoClienteSaida ProdutoClienteSaida { get; set; }
    }
}
