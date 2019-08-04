using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            this.EmpresaFornecedors = new List<EmpresaFornecedor>();
            this.FornecedorContatoes = new List<FornecedorContato>();
            this.ProdutoFornecedorEntradas = new List<ProdutoFornecedorEntrada>();
        }

        public int FornecedorId { get; set; }
        public string NomeFornecedor { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public byte[] ImagemCliente { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public string Contato { get; set; }
        public virtual ICollection<EmpresaFornecedor> EmpresaFornecedors { get; set; }
        public virtual ICollection<FornecedorContato> FornecedorContatoes { get; set; }
        public virtual ICollection<ProdutoFornecedorEntrada> ProdutoFornecedorEntradas { get; set; }
    }
}
