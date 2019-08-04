using System.Collections.Generic;

namespace Loja.Domain.Entities
{
    public  class ProdutoFormasDePagamento
    {
        protected ProdutoFormasDePagamento()
        {
            ProdutoClienteSaidas = new List<ProdutoClienteSaida>();
        }

        public ProdutoFormasDePagamento(int produtoFormasDePagamentoId, string nomeFormaPagamento, bool? ativo,
                                     ICollection<ProdutoClienteSaida> produtoClienteSaida)
        {
            ProdutoFormasDePagamentoId = produtoFormasDePagamentoId;
            NomeFormaPagamento = nomeFormaPagamento;
            Ativo = ativo;
            ProdutoClienteSaidas = produtoClienteSaida;
        }

        public ProdutoFormasDePagamento(string nomeFormaPagamento, bool? ativo = true, int produtoFormasDePagamentoId = 0)
        {
            ProdutoFormasDePagamentoId = produtoFormasDePagamentoId;
            NomeFormaPagamento = nomeFormaPagamento;
            Ativo = ativo;

        }

        public int ProdutoFormasDePagamentoId { get; private set; }
        public string NomeFormaPagamento { get; private set; }
        public bool? Ativo { get; private set; }
        public virtual ICollection<ProdutoClienteSaida> ProdutoClienteSaidas { get; private set; }
    }
}
