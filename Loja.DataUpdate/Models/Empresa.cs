using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            this.EmpresaClientes = new List<EmpresaCliente>();
            this.EmpresaContatoes = new List<EmpresaContato>();
            this.EmpresaFornecedors = new List<EmpresaFornecedor>();
            this.Menus = new List<Menu>();
            this.ProdutoEstoques = new List<ProdutoEstoque>();
            this.ProdutoFornecedorEntradas = new List<ProdutoFornecedorEntrada>();
            this.Usuarios = new List<Usuario>();
            this.ProdutoClienteSaidas = new List<ProdutoClienteSaida>();
        }

        public int EmpresaId { get; set; }
        public string NomeEmpresa { get; set; }
        public string NomeFantasia { get; set; }
        public string Contato { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public byte[] EmpresaImagem { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual ICollection<EmpresaCliente> EmpresaClientes { get; set; }
        public virtual ICollection<EmpresaContato> EmpresaContatoes { get; set; }
        public virtual ICollection<EmpresaFornecedor> EmpresaFornecedors { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<ProdutoEstoque> ProdutoEstoques { get; set; }
        public virtual ICollection<ProdutoFornecedorEntrada> ProdutoFornecedorEntradas { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<ProdutoClienteSaida> ProdutoClienteSaidas { get; set; }
    }
}
