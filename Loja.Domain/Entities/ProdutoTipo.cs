using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public  class ProdutoTipo
    {
        protected ProdutoTipo()
        {
            Produtos = new List<Produto>();
        }

        public ProdutoTipo(int produtoTipoId, string nomeProdutoTipo, bool? ativo, ICollection<Produto> produtos)
        {
            ProdutoTipoId = produtoTipoId;
            NomeProdutoTipo = nomeProdutoTipo;
            Ativo = ativo;
            Produtos = produtos;
        }

        public ProdutoTipo(int produtoTipoId, string nomeProdutoTipo, bool? ativo)
        {
            ProdutoTipoId = produtoTipoId;
            NomeProdutoTipo = nomeProdutoTipo;
            Ativo = ativo;
          
        }

        [DataMember(Name = "ProdutoTipoId")]
        public int ProdutoTipoId { get; private set; }
         [DataMember(Name = "NomeProdutoTipo")]
        public string NomeProdutoTipo { get; private set; }
         [DataMember(Name = "Ativo")]
        public bool? Ativo { get;  set; }
         [DataMember(Name = "Produtos")]
        public virtual ICollection<Produto> Produtos { get; private set; }
    }
}
