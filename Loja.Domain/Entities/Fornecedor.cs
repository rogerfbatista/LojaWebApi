using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public class Fornecedor
    {

        protected Fornecedor()
        {
            EmpresaFornecedores = new List<EmpresaFornecedor>();
            FornecedorContatos = new List<FornecedorContato>();
            ProdutoFornecedorEntradas = new List<ProdutoFornecedorEntrada>();
        }

        public Fornecedor(int fornecedorId, string nomeFornecedor, string cnpj, string inscricaoEstadual, string endereco, string numero,
                            string estado, string cidade, byte[] imagemCliente, bool? ativo, ICollection<EmpresaFornecedor> empresaFornecedor,
                          ICollection<FornecedorContato> fornecedorContato, ICollection<ProdutoFornecedorEntrada> produtoFornecedorEntrada)
        {

            FornecedorId = fornecedorId;
            NomeFornecedor = nomeFornecedor;
            Cnpj = cnpj;
            InscricaoEstadual = inscricaoEstadual;
            Endereco = endereco;
            Numero = numero;
            Estado = estado;
            Cidade = cidade;
            ImagemCliente = imagemCliente;
            Ativo = ativo;
            EmpresaFornecedores = empresaFornecedor;
            FornecedorContatos = fornecedorContato;
            ProdutoFornecedorEntradas = produtoFornecedorEntrada;
        }

        public Fornecedor(int fornecedorId, string nomeFornecedor, string cnpj, string inscricaoEstadual, string endereco, string numero,
                            string estado, string cidade, byte[] imagemCliente, bool? ativo)
        {

            FornecedorId = fornecedorId;
            NomeFornecedor = nomeFornecedor;
            Cnpj = cnpj;
            InscricaoEstadual = inscricaoEstadual;
            Endereco = endereco;
            Numero = numero;
            Estado = estado;
            Cidade = cidade;
            ImagemCliente = imagemCliente;
            Ativo = ativo;

        }

        [DataMember(Name = "FornecedorId")]
        public int FornecedorId { get; private set; }
        [DataMember(Name = "NomeFornecedor")]
        public string NomeFornecedor { get; private set; }

        [DataMember(Name = "Contato")]
        public string Contato { get; private set; }

        [DataMember(Name = "Cnpj")]
        public string Cnpj { get; private set; }
        [DataMember(Name = "InscricaoEstadual")]
        public string InscricaoEstadual { get; private set; }
        [DataMember(Name = "Endereco")]
        public string Endereco { get; private set; }
        [DataMember(Name = "Numero")]
        public string Numero { get; private set; }
        [DataMember(Name = "Estado")]
        public string Estado { get; private set; }
        [DataMember(Name = "Cidade")]
        public string Cidade { get; private set; }
        [DataMember(Name = "ImagemCliente")]
        public byte[] ImagemCliente { get; private set; }
        [DataMember(Name = "Ativo")]
        public bool? Ativo { get;  set; }
        [DataMember(Name = "EmpresaFornecedores")]
        public virtual ICollection<EmpresaFornecedor> EmpresaFornecedores { get; private set; }
        [DataMember(Name = "FornecedorContatos")]
        public virtual ICollection<FornecedorContato> FornecedorContatos { get; private set; }
        [DataMember(Name = "ProdutoFornecedorEntradas")]
        public virtual ICollection<ProdutoFornecedorEntrada> ProdutoFornecedorEntradas { get; private set; }
    }
}
