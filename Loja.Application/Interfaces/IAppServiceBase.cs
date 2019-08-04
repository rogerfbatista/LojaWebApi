
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Loja.Application.Interfaces
{
    public interface IAppServiceBase<T> : IDisposable where T : class
    {
        #region Metodos Interface

        Task RemoveLogic(int id, T obj);
        Task Add(T obj);
        Task Add(List<T> obj);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(Func<T, bool> predicate);
        Task Update(T obj);
        Task Update(List<T> obj);
        Task RemovePhysical(T obj);
        Task Dispose();
        Task<IEnumerable<object>> GetAllPagination(int pageNumber, int pageSize, Func<T, int> orderByFunc, Func<T, bool> countFunc, Func<T, bool> predicate);


        #endregion

    }
}
