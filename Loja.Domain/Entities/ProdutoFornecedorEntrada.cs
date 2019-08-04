using System;
using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public class ProdutoFornecedorEntrada
    {
        private DateTime? _dataEntrada;

        protected ProdutoFornecedorEntrada()
        {

        }

        public ProdutoFornecedorEntrada(int produtoEntradaId, int? produtoId, int? fornecedorId, int? empresaId,
                                       string notaFiscalId, int? quantidadeEntrada, decimal? valorUnitario, DateTime? dataEntrada,
                                       DateTime? dataEmissao, DateTime? dataVencimento, bool? ativo, Empresa empresa, Fornecedor fornecedor,
                                       Produto produto)
        {
            ProdutoEntradaId = produtoEntradaId;
            ProdutoId = produtoId;
            FornecedorId = fornecedorId;
            EmpresaId = empresaId;
            NotaFiscalId = notaFiscalId;
            QuantidadeEntrada = quantidadeEntrada;
            ValorUnitario = valorUnitario;
            DataEntrada = dataEntrada;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            Ativo = ativo;
            Empresa = empresa;
            Fornecedor = fornecedor;
            Produto = produto;
        }

        public ProdutoFornecedorEntrada(int produtoEntradaId, int? produtoId, int? fornecedorId, int? empresaId,
                                       string notaFiscalId, int? quantidadeEntrada, decimal? valorUnitario, DateTime? dataEntrada,
                                       DateTime? dataEmissao, DateTime? dataVencimento, bool? ativo)
        {
            ProdutoEntradaId = produtoEntradaId;
            ProdutoId = produtoId;
            FornecedorId = fornecedorId;
            EmpresaId = empresaId;
            NotaFiscalId = notaFiscalId;
            QuantidadeEntrada = quantidadeEntrada;
            ValorUnitario = valorUnitario;
            DataEntrada = dataEntrada;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            Ativo = ativo;

        }

        [DataMember(Name = "ProdutoEntradaId")]
        public int ProdutoEntradaId { get; private set; }

        [DataMember(Name = "ProdutoId")]
        public int? ProdutoId { get; private set; }

        [DataMember(Name = "FornecedorId")]
        public int? FornecedorId { get; private set; }

        [DataMember(Name = "EmpresaId")]
        public int? EmpresaId { get; private set; }

        [DataMember(Name = "NotaFiscalId")]
        public string NotaFiscalId { get; private set; }

        [DataMember(Name = "QuantidadeEntrada")]
        public int? QuantidadeEntrada { get; private set; }

        [DataMember(Name = "ValorUnitario")]
        public decimal? ValorUnitario { get; private set; }

        [DataMember(Name = "DataEntrada")]
        public DateTime? DataEntrada
        {
            get { return _dataEntrada; }
            private set { _dataEntrada = value ?? DateTime.Now; }
        }

        [DataMember(Name = "DataEmissao")]
        public DateTime? DataEmissao { get; private set; }

        [DataMember(Name = "DataVencimento")]
        public DateTime? DataVencimento { get; private set; }

        [DataMember(Name = "Ativo")]
        public bool? Ativo { get; private set; }

        [DataMember(Name = "Empresa")]
        public virtual Empresa Empresa { get; private set; }

        [DataMember(Name = "Fornecedor")]
        public virtual Fornecedor Fornecedor { get; private set; }

        [DataMember(Name = "Produto")]
        public virtual Produto Produto { get; private set; }

        public void SetAtivo()
        {
            Ativo = false;
        }
    }
}
