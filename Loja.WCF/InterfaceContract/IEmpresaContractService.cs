
using System.ServiceModel;
using Loja.Domain.Entities;

namespace Loja.WCF.InterfaceContract
{
    [ServiceContract]
    public interface IEmpresaContractService : IServiceContractBase<Empresa>
    {

    }
}
