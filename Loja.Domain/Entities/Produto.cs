using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public class Produto
    {
        private DateTime? _dataCastro;

        protected Produto()
        {
           
            ProdutoEstoques = new List<ProdutoEstoque>();
            ProdutoFornecedorEntradas = new List<ProdutoFornecedorEntrada>();
            ProdutoClienteSaidaItems = new List<ProdutoClienteSaidaItem>();
        }

        public Produto(int produtoId, int? produtoTipoId, int? empresaId, string codigoReferencia, string nomeProduto,
                         DateTime? dataCastro, byte[] imagemCliente, bool? ativo, ICollection<ProdutoEstoque> produtoEstoques,
                        ICollection<ProdutoFornecedorEntrada> produtoFornecedorEntradas, ProdutoTipo produtoTipo, ICollection<ProdutoClienteSaidaItem> produtoClienteSaidaItems)
        {
            ProdutoTipoId = produtoTipoId;
            ProdutoId = produtoId;
            EmpresaId = empresaId;
            CodigoReferencia = codigoReferencia;
            NomeProduto = nomeProduto;
            DataCastro = dataCastro;
            ImagemCliente = imagemCliente;
            Ativo = ativo;
           ProdutoEstoques = produtoEstoques;
            ProdutoFornecedorEntradas = produtoFornecedorEntradas;
            ProdutoTipo = produtoTipo;
            ProdutoClienteSaidaItems = produtoClienteSaidaItems;
        }


        public Produto(int produtoId, int? produtoTipoId, int? empresaId, string codigoReferencia, string nomeProduto,
                        DateTime? dataCastro, byte[] imagemCliente, bool? ativo)
        {
            ProdutoTipoId = produtoTipoId;
            ProdutoId = produtoId;
            EmpresaId = empresaId;
            CodigoReferencia = codigoReferencia;
            NomeProduto = nomeProduto;
            DataCastro = dataCastro;
            ImagemCliente = imagemCliente;
            Ativo = ativo;

        }


        [DataMember(Name = "ProdutoId")]
        public int ProdutoId { get; private set; }
        [DataMember(Name = "ProdutoTipoId")]
        public int? ProdutoTipoId { get; private set; }
        [DataMember(Name = "EmpresaId")]
        public int? EmpresaId { get; private set; }
        [DataMember(Name = "CodigoReferencia")]
        public string CodigoReferencia { get; private set; }
        [DataMember(Name = "NomeProduto")]
        public string NomeProduto { get; private set; }

        [DataMember(Name = "DataCastro")]
        public DateTime? DataCastro
        {
            get { return _dataCastro; }
            private set {
                _dataCastro = value ?? DateTime.Now;
            }
        }

        [DataMember(Name = "ImagemCliente")]
        public byte[] ImagemCliente { get; private set; }
        [DataMember(Name = "Ativo")]
        public bool? Ativo { get; set; }
      
        [DataMember(Name = "ProdutoEstoques")]
        public virtual ICollection<ProdutoEstoque> ProdutoEstoques { get; private set; }
        [DataMember(Name = "ProdutoFornecedorEntradas")]
        public virtual ICollection<ProdutoFornecedorEntrada> ProdutoFornecedorEntradas { get; private set; }
        [DataMember(Name = "ProdutoTipo")]
        public virtual ProdutoTipo ProdutoTipo { get; private set; }

        [DataMember(Name = "ProdutoClienteSaidaItems")]
        public virtual ICollection<ProdutoClienteSaidaItem> ProdutoClienteSaidaItems { get; private set; }

    }
}
