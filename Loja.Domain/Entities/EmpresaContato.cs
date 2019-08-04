
using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public class EmpresaContato
    {
        protected EmpresaContato() { }

        public EmpresaContato(int empresaContatoId, int? empresaId, string email, string telefone, bool? ativo,
            Empresa empresa)
        {
            EmpresaContatoId = empresaContatoId;
            EmpresaId = empresaId;
            Email = email;
            Telefone = telefone;
            Ativo = ativo;
            Empresa = empresa;
        }

        public EmpresaContato(string email, string telefone, bool? ativo = true, int empresaContatoId = 0, int? empresaId = 0)
        {
            EmpresaContatoId = empresaContatoId;
            EmpresaId = empresaId;
            Email = email;
            Telefone = telefone;
            Ativo = ativo;

        }

        [DataMember(Name = "EmpresaContatoId")]
        public int EmpresaContatoId { get; private set; }
        [DataMember(Name = "EmpresaId")]
        public int? EmpresaId { get; private set; }
        [DataMember(Name = "Email")]
        public string Email { get; private set; }
        [DataMember(Name = "Telefone")]
        public string Telefone { get; private set; }
        [DataMember(Name = "Ativo")]
        public bool? Ativo { get;  set; }
        [DataMember(Name = "Empresa", IsRequired = false)]
        public virtual Empresa Empresa { get; set; }
    }
}
