using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{

    [DataContract]
    public class Cliente
    {


        protected Cliente()
        {
            ClienteContatos = new List<ClienteContato>();
            EmpresaClientes = new List<EmpresaCliente>();
            ProdutoClienteSaidas = new List<ProdutoClienteSaida>();
        }

        public Cliente(int clienteId, string nomeCliente, string CpfCnpj, byte[] imagemCliente, bool? ativo = true)
        {
            ClienteId = clienteId;
            NomeCliente = nomeCliente;
            this.CpfCnpj = CpfCnpj;
            ImagemCliente = imagemCliente;
            Ativo = ativo;
        }

        public Cliente(int clienteId, string nomeCliente, string cpfCnpj, byte[] imagemCliente,
            ICollection<ClienteContato> clienteContato, ICollection<EmpresaCliente> empresaCliente,
             bool ativo = true, ICollection<ProdutoClienteSaida> produtoClienteSaidas = null)
        {
            ClienteId = clienteId;
            NomeCliente = nomeCliente;
            CpfCnpj = cpfCnpj;
            ImagemCliente = imagemCliente;
            Ativo = ativo;
            ClienteContatos = clienteContato;
            EmpresaClientes = empresaCliente;
            ProdutoClienteSaidas = produtoClienteSaidas;
        }

        [DataMember(Name = "ClienteId")]
        public int ClienteId { get; private set; }
        [DataMember(Name = "NomeCliente")]
        public string NomeCliente { get; private set; }
        [DataMember(Name = "CpfCnpj")]
        public string CpfCnpj { get; private set; }
        [DataMember(Name = "ImagemCliente")]
        public byte[] ImagemCliente { get; private set; }
        [DataMember(Name = "Ativo")]
        public bool? Ativo { get; set; }
        [DataMember(Name = "ClienteContatos")]
        public virtual ICollection<ClienteContato> ClienteContatos { get; private set; }
        [DataMember(Name = "EmpresaClientes")]
        public virtual ICollection<EmpresaCliente> EmpresaClientes { get; private set; }

        [DataMember(Name = "ProdutoClienteSaidaItems")]
        public virtual ICollection<ProdutoClienteSaida> ProdutoClienteSaidas { get; private set; }
    }
}

