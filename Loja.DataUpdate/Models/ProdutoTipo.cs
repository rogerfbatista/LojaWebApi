using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class ProdutoTipo
    {
        public ProdutoTipo()
        {
            this.Produtoes = new List<Produto>();
        }

        public int ProdutoTipoId { get; set; }
        public string NomeProdutoTipo { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual ICollection<Produto> Produtoes { get; set; }
    }
}
