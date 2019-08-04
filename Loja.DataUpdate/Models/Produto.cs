using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class Produto
    {
        public Produto()
        {
            this.ProdutoEstoques = new List<ProdutoEstoque>();
            this.ProdutoFornecedorEntradas = new List<ProdutoFornecedorEntrada>();
            this.ProdutoClienteSaidaItems = new List<ProdutoClienteSaidaItem>();
        }

        public int ProdutoId { get; set; }
        public Nullable<int> ProdutoTipoId { get; set; }
        public Nullable<int> EmpresaId { get; set; }
        public string CodigoReferencia { get; set; }
        public string NomeProduto { get; set; }
        public Nullable<System.DateTime> DataCastro { get; set; }
        public byte[] ImagemCliente { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual ProdutoTipo ProdutoTipo { get; set; }
        public virtual ICollection<ProdutoEstoque> ProdutoEstoques { get; set; }
        public virtual ICollection<ProdutoFornecedorEntrada> ProdutoFornecedorEntradas { get; set; }
        public virtual ICollection<ProdutoClienteSaidaItem> ProdutoClienteSaidaItems { get; set; }
    }
}
