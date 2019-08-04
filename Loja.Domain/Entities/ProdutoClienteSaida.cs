using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public class ProdutoClienteSaida
    {
        protected ProdutoClienteSaida()
        {
            ProdutoClienteSaidaItems = new List<ProdutoClienteSaidaItem>();
        }

        public ProdutoClienteSaida(int produtoClienteSaidaId,int? empresaId,int? produtoFormasDePagamentoId,  decimal? valorTotal, DateTime? dataVenda,
                                   bool? ativo, Empresa empresa, ProdutoFormasDePagamento produtoFormasDePagamento, ICollection<ProdutoClienteSaidaItem> produtoClienteSaidaItems)
        {
            ProdutoClienteSaidaId = produtoClienteSaidaId;
          
            EmpresaId = empresaId;
            ProdutoFormasDePagamentoId = produtoFormasDePagamentoId;
            ValorTotal = valorTotal;
            DataVenda = dataVenda;
            Ativo = ativo;
            Empresa = empresa;
           ProdutoFormasDePagamento = produtoFormasDePagamento;
            ProdutoClienteSaidaItems = produtoClienteSaidaItems;
        }

        public ProdutoClienteSaida(int produtoClienteSaidaId,  int? empresaId,
                                  int? produtoFormasDePagamentoId,  decimal? valorTotal, DateTime? dataVenda,
                                  bool? ativo)
        {
            ProdutoClienteSaidaId = produtoClienteSaidaId;
         
            EmpresaId = empresaId;
            ProdutoFormasDePagamentoId = produtoFormasDePagamentoId;
        
            ValorTotal = valorTotal;
            DataVenda = dataVenda;
            Ativo = ativo;
         
        }



        [DataMember(Name = "ProdutoClienteSaidaId")]
        public int ProdutoClienteSaidaId { get; private set; }
     

      
        [DataMember(Name = "EmpresaId")]
        public int? EmpresaId { get; private set; }

        [DataMember(Name = "ProdutoFormasDePagamentoId")]
        public int? ProdutoFormasDePagamentoId { get; private set; }


        [DataMember(Name = "ValorTotal")]
        public decimal? ValorTotal { get; private set; }

        [DataMember(Name = "DataVenda")]
        public DateTime? DataVenda { get; private set; }

        [DataMember(Name = "Ativo")]
        public bool? Ativo { get; private set; }

        [DataMember(Name = "ClienteId")]
        public int? ClienteId { get; private set; }


        [DataMember(Name = "Cliente")]
        public virtual Cliente Cliente { get; private set; }

        [DataMember(Name = "Empresa")]
        public virtual Empresa Empresa { get; private set; }


        [DataMember(Name = "ProdutoFormasDePagamento")]
        public virtual ProdutoFormasDePagamento ProdutoFormasDePagamento { get; private set; }

         [DataMember(Name = "ProdutoClienteSaidaItems")]
        public virtual ICollection<ProdutoClienteSaidaItem> ProdutoClienteSaidaItems { get; set; }

        
        public void SetAtivoFalse()
        {
            Ativo = false;
        }
    }
}
