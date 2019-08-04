using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Loja.Application.Interfaces;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class AppServiceBase<T> : IDisposable, IAppServiceBase<T> where T : class
    {
        private readonly IServiceBase<T> _serviceBase;

        #region Construtor DI

        public AppServiceBase(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        #endregion


        #region Metodos

        public async Task Dispose()
        {
            await _serviceBase.Dispose();
        }

        public async Task Add(T obj)
        {
            await _serviceBase.Add(obj);
        }

        public async Task<T> GetById(int id)
        {
            return await _serviceBase.GetById(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _serviceBase.GetAll();
        }

        public async Task Update(T obj)
        {
            await _serviceBase.Update(obj);
        }

        public async Task RemovePhysical(T obj)
        {
            await _serviceBase.RemovePhysical(obj);
        }

        async void IDisposable.Dispose()
        {
            await _serviceBase.Dispose();
        }


        public async Task<List<T>> GetAll(Func<T, bool> predicate)
        {
            return await _serviceBase.GetAll(predicate);
        }


        public async Task RemoveLogic(int id, T obj)
        {
            await _serviceBase.RemoveLogic(id, obj);
        }


        public async Task Add(List<T> obj)
        {
            await _serviceBase.Add(obj);
        }

        #endregion


        public async Task Update(List<T> obj)
        {
            await _serviceBase.Update(obj);
        }

        public async Task<IEnumerable<object>> GetAllPagination(int pageNumber, int pageSize, Func<T, int> orderByFunc, Func<T, bool> countFunc, Func<T, bool> predicate)
        {
            return await _serviceBase.GetAllPagination(pageNumber, pageSize, orderByFunc, countFunc, predicate);
        }

    }

}
