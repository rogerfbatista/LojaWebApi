using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public  class Empresa
    {
        protected Empresa()
        {
            EmpresaContatos = new List<EmpresaContato>();
            EmpresaClientes = new List<EmpresaCliente>();
            EmpresaFornecedores = new List<EmpresaFornecedor>();
            Menus = new List<Menu>();
            ProdutoClienteSaidas = new List<ProdutoClienteSaida>();
            ProdutoEstoques = new List<ProdutoEstoque>();
            ProdutoFornecedorEntradas = new List<ProdutoFornecedorEntrada>();
            Usuarios = new List<Usuario>();
        }

        public Empresa(string nomeEmpresa, string nomeFantasia, string contato, string inscricaoEstadual, string cnpj,
                       string endereco, string numero, string estado, string cidade, DateTime? dataCadastro, byte[] empresaImagem,
                        ICollection<EmpresaContato> empresaContatos, ICollection<EmpresaCliente> empresaClientes,
                       ICollection<EmpresaFornecedor> empresaFornecedores, ICollection<Menu> menus, ICollection<ProdutoClienteSaida> produtoClienteSaidas,
                       ICollection<ProdutoEstoque> produtoEstoques, ICollection<ProdutoFornecedorEntrada> produtoFornecedorEntradas,
                       ICollection<Usuario> usuarios, int empresaId = 0, bool? ativo = true,EmpresaContato empresaContato = null)
        {
            EmpresaId = empresaId;
            NomeEmpresa = nomeEmpresa;
            NomeFantasia = nomeFantasia;
            Contato = contato;
            InscricaoEstadual = inscricaoEstadual;
            Cnpj = cnpj;
            Endereco = endereco;
            Numero = numero;
            Estado = estado;
            Cidade = cidade;
            DataCadastro = dataCadastro ?? DateTime.Now;
            EmpresaImagem = empresaImagem;
            Ativo = ativo;
            EmpresaContatos = empresaContatos;
            EmpresaClientes = empresaClientes;
            EmpresaFornecedores = empresaFornecedores;
            Menus = menus;
            ProdutoClienteSaidas = produtoClienteSaidas;
            ProdutoEstoques = produtoEstoques;
            ProdutoFornecedorEntradas = produtoFornecedorEntradas;
            Usuarios = usuarios;
            
        }

        public Empresa(string nomeEmpresa, string nomeFantasia, string contato, string inscricaoEstadual, string cnpj,
                    string endereco, string numero, string estado, string cidade, DateTime? dataCadastro, byte[] empresaImagem,
                    bool? ativo = true, int empresaId = 0, ICollection<EmpresaContato> empresaContatos = null)
        {
            EmpresaId = empresaId;
            NomeEmpresa = nomeEmpresa;
            NomeFantasia = nomeFantasia;
            Contato = contato;
            InscricaoEstadual = inscricaoEstadual;
            Cnpj = cnpj;
            Endereco = endereco;
            Numero = numero;
            Estado = estado;
            Cidade = cidade;
            DataCadastro = dataCadastro ?? DateTime.Now;
            EmpresaImagem = empresaImagem;
            Ativo = ativo;
            EmpresaContatos = empresaContatos;
         
        }

        [DataMember(Name = "EmpresaId")]
        public int EmpresaId { get; private set; }
        [DataMember(Name = "NomeEmpresa")]
        public string NomeEmpresa { get; private set; }
        [DataMember(Name = "NomeFantasia")]
        public string NomeFantasia { get; private set; }
        [DataMember(Name = "Contato")]
        public string Contato { get; private set; }
        [DataMember(Name = "InscricaoEstadual")]
        public string InscricaoEstadual { get; private set; }
        [DataMember(Name = "Cnpj")]
        public string Cnpj { get; private set; }
        [DataMember(Name = "Endereco")]
        public string Endereco { get; private set; }
        [DataMember(Name = "Numero")]
        public string Numero { get; private set; }
        [DataMember(Name = "Estado")]
        public string Estado { get; private set; }
        [DataMember(Name = "Cidade")]
        public string Cidade { get; private set; }
        [DataMember(Name = "DataCadastro")]
        public DateTime? DataCadastro { get; private set; }
        [DataMember(Name = "EmpresaImagem")]
        public byte[] EmpresaImagem { get; private set; }
        [DataMember(Name = "Ativo")]
        public bool? Ativo { get;  set; }


        [DataMember(Name = "EmpresaContatos")]
        public ICollection<EmpresaContato> EmpresaContatos { get; private set; }
        [DataMember(Name = "EmpresaClientes")]
        public ICollection<EmpresaCliente> EmpresaClientes { get; private set; }
        [DataMember(Name = "EmpresaFornecedores")]
        public ICollection<EmpresaFornecedor> EmpresaFornecedores { get; private set; }
        [DataMember(Name = "Menus")]
        public ICollection<Menu> Menus { get; private set; }
        [DataMember(Name = "ProdutoClienteSaidas")]
        public ICollection<ProdutoClienteSaida> ProdutoClienteSaidas { get; private set; }
        [DataMember(Name = "ProdutoEstoques")]
        public ICollection<ProdutoEstoque> ProdutoEstoques { get; private set; }
        [DataMember(Name = "ProdutoFornecedorEntradas")]
        public ICollection<ProdutoFornecedorEntrada> ProdutoFornecedorEntradas { get; private set; }
        [DataMember(Name = "Usuarios")]
        public ICollection<Usuario> Usuarios { get; private set; }
    }
}
