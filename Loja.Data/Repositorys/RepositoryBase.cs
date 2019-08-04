using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Loja.Common;
using Loja.Data.Contexto;
using Loja.Domain.Interfaces.Repositorys;

namespace Loja.Data.Repositorys
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        protected LojaContext DbContext = new LojaContext();

        public async Task Add(T obj)
        {
            using (DbContext = new LojaContext())
            {

                DbContext.Configuration.AutoDetectChangesEnabled = false;
                DbContext.Set<T>().Add(obj);
                await DbContext.SaveChangesAsync();
                DbContext.Configuration.AutoDetectChangesEnabled = true;
            }



        }

        public async Task Add(List<T> obj)
        {
            using (DbContext = new LojaContext())
            {
                foreach (var item in obj)
                {

                    DbContext.Configuration.AutoDetectChangesEnabled = false;
                    DbContext.Set<T>().Add(item);
                    await DbContext.SaveChangesAsync();
                    DbContext.Configuration.AutoDetectChangesEnabled = true;
                }
            }



        }

        public async Task<T> GetById(int id)
        {
            using (DbContext = new LojaContext())
            {
                DbContext.Configuration.AutoDetectChangesEnabled = false;
                return await DbContext.Set<T>().FindAsync(id);
            }

        }

        public async Task<List<T>> GetAll()
        {
            using (DbContext = new LojaContext())
            {
                DbContext.Configuration.AutoDetectChangesEnabled = false;
                return await DbContext.Set<T>().ToListAsync();
            }
        }

        public async Task<IEnumerable<object>> GetAllPagination(int pageNumber,
                                                                int pageSize,
                                                                Func<T, int> orderByFunc,
                                                                Func<T, bool> countFunc,
                                                                Func<T, bool> predicate)
        {
            using (DbContext = new LojaContext())
            {

                DbContext.Configuration.AutoDetectChangesEnabled = false;
                var recordsTotal = DbContext.Set<T>().Count(countFunc);


                var list = DbContext.Set<T>()
                    .OrderBy(orderByFunc)
                    .Where(predicate)
                       .Skip(pageSize * (pageNumber - 1))
                       .Take(pageSize)
                       .ToList();

                var lista = new List<object>
                {
                    new
                    {
                        recordsTotal,
                        list
                    }
                };


                return await Task.Factory.StartNew(() => lista);

            }
        }

        public async Task Update(T obj)
        {

            new Util<T>().SetUpdateObject(ref obj);


            using (DbContext = new LojaContext())
            {
                DbContext.Configuration.AutoDetectChangesEnabled = false;
                DbContext.Entry(obj).State = EntityState.Modified;
                await DbContext.SaveChangesAsync();
                DbContext.Configuration.AutoDetectChangesEnabled = true;
            }

        }

        public async Task RemovePhysical(T obj)
        {
            try
            {
                using (DbContext = new LojaContext())
                {
                    DbContext.Configuration.AutoDetectChangesEnabled = false;

                    DbContext.Entry(obj).State = EntityState.Deleted;
                    await DbContext.SaveChangesAsync();
                    DbContext.Configuration.AutoDetectChangesEnabled = true;
                }


            }
            catch (Exception ex)
            {

                if (ex.Message == "An error occurred while updating the entries. See the inner exception for details.")
                {
                    throw new Exception("Não é possivel excluir Existem Cadastro Relacionados");
                }
                else
                {

                    throw new Exception(ex.Message);
                }

            }

        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        async Task IRepositoryBase<T>.Dispose()
        {

            await Task.Factory.StartNew(() => DbContext.Dispose());
        }


        public async Task<List<T>> GetAll(Func<T, bool> predicate)
        {
            using (DbContext = new LojaContext())
            {
                DbContext.Configuration.AutoDetectChangesEnabled = false;
                return await Task.Factory.StartNew(() => DbContext.Set<T>().Where(predicate).ToList());
            }
        }


        public async Task RemoveLogic(int id, T obj)
        {
            using (DbContext = new LojaContext())
            {
                DbContext.Configuration.AutoDetectChangesEnabled = false;
                DbContext.Entry(obj).State = EntityState.Modified;
                await DbContext.SaveChangesAsync();
                DbContext.Configuration.AutoDetectChangesEnabled = true;
            }
        }


        public async Task Update(List<T> obj)
        {
            foreach (var item in obj.ToArray())
            {
                var itemObj = item;

                new Util<T>().SetUpdateObject(ref itemObj);


                using (DbContext = new LojaContext())
                {
                    DbContext.Configuration.AutoDetectChangesEnabled = false;
                    DbContext.Entry(itemObj).State = EntityState.Modified;
                    await DbContext.SaveChangesAsync();
                    DbContext.Configuration.AutoDetectChangesEnabled = true;
                }
            }
        }
    }
}
