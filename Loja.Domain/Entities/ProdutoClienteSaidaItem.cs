using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public class ProdutoClienteSaidaItem
    {
        protected ProdutoClienteSaidaItem()
        {
           
        }

        public ProdutoClienteSaidaItem(int produtoClienteSaidaItemId, int? produtoClienteSaidaId, int? produtoId, int? clienteId, int? quantidadeSaida,
            decimal? subTotal, bool? ativo,  Produto produto = null, ProdutoClienteSaida produtoClienteSaida = null)
        {
            ProdutoClienteSaidaItemId = produtoClienteSaidaItemId;
            ProdutoClienteSaidaId = produtoClienteSaidaId;
            ProdutoId = produtoId;
            QuantidadeSaida = quantidadeSaida;
            SubTotal = subTotal;
            Ativo = ativo;
            Produto = produto;
            ProdutoClienteSaida = produtoClienteSaida;

        }


        [DataMember(Name = "ProdutoClienteSaidaItemId")]
        public int ProdutoClienteSaidaItemId { get; private set; }

        [DataMember(Name = "ProdutoClienteSaidaId")]
        public int? ProdutoClienteSaidaId { get; private set; }


         [DataMember(Name = "ProdutoId")]
        public int? ProdutoId { get; private set; }

         

         [DataMember(Name = "QuantidadeSaida")]
        public int? QuantidadeSaida { get; private set; }
         [DataMember(Name = "SubTotal")]
         public decimal? SubTotal { get; private set; }
         [DataMember(Name = "Ativo")]
        public bool? Ativo { get; private set; }
        
         [DataMember(Name = "Produto")]
        public virtual Produto Produto { get; private set; }

         [DataMember(Name = "ProdutoClienteSaida")]
         public virtual ProdutoClienteSaida ProdutoClienteSaida { get; set; }


        public void SetAtivoFalse()
        {
            Ativo = false;
        }
    }
}