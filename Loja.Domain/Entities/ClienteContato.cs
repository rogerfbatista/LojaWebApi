
using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public  class ClienteContato
    {
       

        protected ClienteContato()
        {

        }

        public ClienteContato( int clienteContatoId, int clienteId, string email, string telefone, bool ativo)
        {
            ClienteContatoId = clienteContatoId;
            ClienteId = clienteId;
            Email = email;
            Telefone = telefone;
            Ativo = ativo;
           
        }

        public ClienteContato( int clienteContatoId, int clienteId, string email, string telefone, bool ativo, Cliente cliente)
        {
            ClienteContatoId = clienteContatoId;
            ClienteId = clienteId;
            Email = email;
            Telefone = telefone;
            Ativo = ativo;
            Cliente = cliente;
        }

        [DataMember(Name = "ClienteContatoId")]
        public int ClienteContatoId { get; private set; }
         [DataMember(Name = "ClienteId")]
        public int? ClienteId { get; private set; }
         [DataMember(Name = "Email")]
        public string Email { get; private set; }
         [DataMember(Name = "Telefone")]
        public string Telefone { get; private set; }
         [DataMember(Name = "Ativo")]
        public bool Ativo { get;  set; }
         [DataMember(Name = "Cliente")]
        public virtual Cliente Cliente { get;  set; }
    }
}
