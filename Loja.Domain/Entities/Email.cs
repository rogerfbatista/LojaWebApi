using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public class Email
    {
        public Email() { }

        public Email(string assunto, string mensagem)
        {
            Assunto = assunto;
            Mensagem = mensagem;
            }



        [DataMember(Name = "Assunto")]
        public string Assunto { get; private set; }
        [DataMember(Name = "Mensagem")]
        public string Mensagem { get; private set; }
    }
}
