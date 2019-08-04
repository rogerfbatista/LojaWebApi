using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public  class FornecedorContato
    {
        protected FornecedorContato(){}

        public FornecedorContato(int fornecedorContatoId, int? fornecedorId, string email, string telefone, bool? ativo, Fornecedor fornecedor)
        {
            FornecedorContatoId = fornecedorContatoId;
            FornecedorId = fornecedorId;
            Email = email;
            Telefone = telefone;
            Ativo = ativo;
            Fornecedor = fornecedor;
        }

        public FornecedorContato(int fornecedorContatoId, int? fornecedorId, string email, string telefone, bool? ativo)
        {
            FornecedorContatoId = fornecedorContatoId;
            FornecedorId = fornecedorId;
            Email = email;
            Telefone = telefone;
            Ativo = ativo;
            
        }

        [DataMember(Name = "FornecedorContatoId")]
        public int FornecedorContatoId { get; private set; }
          [DataMember(Name = "FornecedorId")]
        public int? FornecedorId { get; private set; }
          [DataMember(Name = "Email")]
        public string Email { get; private set; }
          [DataMember(Name = "Telefone")]
        public string Telefone { get; private set; }
          [DataMember(Name = "Ativo")]
        public bool? Ativo { get;  set; }
          [DataMember(Name = "Fornecedor")]
        public virtual Fornecedor Fornecedor { get;  set; }
    }
}
