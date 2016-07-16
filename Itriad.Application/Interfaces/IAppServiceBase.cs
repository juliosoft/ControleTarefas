using System.Collections.Generic;

namespace Itriad.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllAsNoTrack();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Save();
        void Dispose();
    }
}
