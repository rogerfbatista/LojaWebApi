using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public  class EmpresaCliente
    {
        protected EmpresaCliente()
        {
            
        }

        public EmpresaCliente(int empresaClienteId, int? clienteId, int? empresaId, bool? ativo, Cliente cliente, Empresa empresa)
        {
            EmpresaClienteId = empresaClienteId;
            ClienteId = clienteId;
            EmpresaId = empresaId;
            Ativo = ativo;
            Cliente = cliente;
            Empresa = empresa;
        }
        public EmpresaCliente(int empresaClienteId, int? clienteId, int? empresaId, bool? ativo)
        {
            EmpresaClienteId = empresaClienteId;
            ClienteId = clienteId;
            EmpresaId = empresaId;
            Ativo = ativo;
          
        }

        [DataMember(Name = "EmpresaClienteId")]
        public int EmpresaClienteId { get; private set; }
        [DataMember(Name = "ClienteId")]
        public int? ClienteId { get; private set; }
        [DataMember(Name = "EmpresaId")]
        public int? EmpresaId { get; private set; }
        [DataMember(Name = "Ativo")]
        public bool? Ativo { get;  set; }
        [DataMember(Name = "Cliente")]
        public virtual Cliente Cliente { get;  set; }
        [DataMember(Name = "Empresa")]
        public virtual Empresa Empresa { get;  set; }
    }
}