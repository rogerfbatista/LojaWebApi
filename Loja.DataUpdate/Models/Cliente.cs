using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            this.ClienteContatoes = new List<ClienteContato>();
            this.EmpresaClientes = new List<EmpresaCliente>();
            this.ProdutoClienteSaidaItems = new List<ProdutoClienteSaidaItem>();
        }

        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public string CpfCnpj { get; set; }
        public byte[] ImagemCliente { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual ICollection<ClienteContato> ClienteContatoes { get; set; }
        public virtual ICollection<EmpresaCliente> EmpresaClientes { get; set; }
        public virtual ICollection<ProdutoClienteSaidaItem> ProdutoClienteSaidaItems { get; set; }
    }
}
