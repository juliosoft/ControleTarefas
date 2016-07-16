using Itriad.Domain.Interfaces.Repositories;
using Itriad.Infra.Data.Context;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Itriad.Infra.Data.Repositories
{

    /// <summary>
    /// Repositório base contendo as operações de crud que podem ser utilizadas e/ou extendidas.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ItriadContexto _contexto;
        protected IDbConnection _dbConnection;

        public RepositoryBase()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager>();
            _contexto = contextManager.Contexto;
        }

        public void Add(TEntity obj)
        {
            _contexto.Set<TEntity>().Add(obj);
        }
        
        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _contexto.Set<TEntity>().ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IEnumerable<TEntity> GetAllAsNoTrack()
        {
            return _contexto.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            return _contexto.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
           _contexto.Set<TEntity>().Remove(obj);
        }

        public void Update(TEntity obj)
        {
            try
            {
                _contexto.Entry(obj).State = EntityState.Modified;
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        //public void Save()
        //{
        //    try
        //    {
        //        _contexto.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException(ex.Message);

        //    }
        //}

        //public void RollBack()
        //{
        //    _contexto.Database.CurrentTransaction.Rollback();
        //}
    }
}
