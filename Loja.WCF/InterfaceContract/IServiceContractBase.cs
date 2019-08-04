using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Loja.WCF.InterfaceContract
{
    [ServiceContract]
    public interface IServiceContractBase<T> : IDisposable where T : class
    {
        [OperationContract]
        Task<List<T>> GetAll();
        [OperationContract]
        Task<T> Get(int id);
        [OperationContract]
        void Add( T obj);
        [OperationContract]
        void Update(T obj);
        [OperationContract]
        void Delete(T obj);
    }
}
