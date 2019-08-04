using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public class ProdutoEstoque
    {
        protected ProdutoEstoque()
        {
            
        }

        public ProdutoEstoque(int produtoEstoqueId, int? empresaId, int? produtoId, int? quantidadeEstoque, decimal? valorVenda,
                             bool? ativo, Empresa empresa, Produto produto)
        {
            ProdutoEstoqueId = produtoEstoqueId;
            EmpresaId = empresaId;
            ProdutoId = produtoId;
            QuantidadeEstoque = quantidadeEstoque;
            ValorVenda = valorVenda;
            Ativo = ativo;
            Empresa = empresa;
            Produto = produto;
        }

        public ProdutoEstoque(int produtoEstoqueId, int? empresaId, int? produtoId, int? quantidadeEstoque, decimal? valorVenda,
                            bool? ativo)
        {
            ProdutoEstoqueId = produtoEstoqueId;
            EmpresaId = empresaId;
            ProdutoId = produtoId;
            QuantidadeEstoque = quantidadeEstoque;
            ValorVenda = valorVenda;
            Ativo = ativo;

        }

        [DataMember(Name = "ProdutoEstoqueId")]
        public int ProdutoEstoqueId { get; private set; }

        [DataMember(Name = "EmpresaId")]
        public int? EmpresaId { get; private set; }

        [DataMember(Name = "ProdutoId")]
        public int? ProdutoId { get; private set; }

        [DataMember(Name = "QuantidadeEstoque")]
        public int? QuantidadeEstoque { get; private set; }

        [DataMember(Name = "ValorVenda")]
        public decimal? ValorVenda { get; private set; }

        [DataMember(Name = "Ativo")]
        public bool? Ativo { get; private set; }

        [DataMember(Name = "Empresa")]
        public virtual Empresa Empresa { get; private set; }

        [DataMember(Name = "Produto")]
        public virtual Produto Produto { get; private set; }

        public void SetEstoque(int? estoque)
        {
            QuantidadeEstoque = estoque;
        }

        public void SetValorVenda(decimal? valorVenda)
        {
            ValorVenda = valorVenda;
        }
    }
}
