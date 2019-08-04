using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract]
    public  class EmpresaFornecedor
    {
        protected EmpresaFornecedor()
        {
            
        }

        public EmpresaFornecedor(int empresaFornecedorId, int? fornecedorId, int? empresaId, bool? ativo, Empresa empresa, Fornecedor fornecedor)
        {
            EmpresaFornecedorId = empresaFornecedorId;
            FornecedorId = fornecedorId;
            EmpresaId = empresaId;
            Ativo = ativo;
            Empresa = empresa;
            Fornecedor = fornecedor;

        }
        public EmpresaFornecedor(int empresaFornecedorId, int? fornecedorId, int? empresaId, bool? ativo)
        {
            EmpresaFornecedorId = empresaFornecedorId;
            FornecedorId = fornecedorId;
            EmpresaId = empresaId;
            Ativo = ativo;
           
        }
        [DataMember(Name = "EmpresaFornecedorId")]
        public int EmpresaFornecedorId { get; private set; }
           [DataMember(Name = "FornecedorId")]
        public int? FornecedorId { get; private set; }
           [DataMember(Name = "EmpresaId")]
        public int? EmpresaId { get; private set; }
           [DataMember(Name = "Ativo")]
        public bool? Ativo { get;  set; }
           [DataMember(Name = "Empresa")]
        public virtual Empresa Empresa { get;  set; }
           [DataMember(Name = "Fornecedor")]
        public virtual Fornecedor Fornecedor { get;  set; }
    }
}
