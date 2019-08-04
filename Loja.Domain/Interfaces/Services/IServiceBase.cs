using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Loja.Domain.Interfaces.Services
{
    public interface IServiceBase<T> : IDisposable where T : class
    {
        Task Add(T obj);
        Task Add(List<T> obj);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(Func<T, bool> predicate);
        Task Update(T obj);
        Task Update(List<T> obj);
        Task RemovePhysical(T obj);
        Task RemoveLogic(int id, T obj);
        Task Dispose();
        Task<IEnumerable<object>> GetAllPagination(int pageNumber, int pageSize, Func<T, int> orderByFunc, Func<T, bool> countFunc, Func<T, bool> predicate);


    }
}
