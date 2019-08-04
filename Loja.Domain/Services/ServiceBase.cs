using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;

namespace Loja.Domain.Services
{
    public class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
    {
        /// <summary>
        /// Implemntar a InterFace do repositorio EF camados Dados Injeçao de dependencia
        /// </summary>
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }



        public async Task Add(T obj)
        {
            await _repository.Add(obj);
        }

        public async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task Update(T obj)
        {
            await _repository.Update(obj);
        }

        public async Task RemovePhysical(T obj)
        {
            await _repository.RemovePhysical(obj);
        }

        async Task IServiceBase<T>.Dispose()
        {
            await _repository.Dispose();
        }

        void IDisposable.Dispose()
        {
            _repository.Dispose();
        }


        public async Task<List<T>> GetAll(Func<T, bool> predicate)
        {
            return await _repository.GetAll(predicate);
        }


        public async Task RemoveLogic(int id, T obj)
        {
            await _repository.RemoveLogic(id, obj);
        }


        public async Task Add(List<T> obj)
        {
            await _repository.Add(obj);
        }


        public async Task Update(List<T> obj)
        {
            await _repository.Update(obj);
        }


        public async Task<IEnumerable<object>> GetAllPagination(int pageNumber, int pageSize, Func<T, int> orderByFunc, Func<T, bool> countFunc, Func<T, bool> predicate)
        {
           return await _repository.GetAllPagination(pageNumber,pageSize,orderByFunc,countFunc,predicate);
        }
    }
}
