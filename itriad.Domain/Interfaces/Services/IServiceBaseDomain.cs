using System.Collections.Generic;

namespace Itriad.Domain.Interfaces.Services
{
    public interface IServiceBaseDomain<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllAsNoTrack();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void BeginTransaction();
        void Save();
        void RollBack();
        void Dispose();
    }
}
