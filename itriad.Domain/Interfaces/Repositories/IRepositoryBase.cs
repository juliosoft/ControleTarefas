using System.Collections.Generic;


namespace Itriad.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllAsNoTrack();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
        //void RollBack();
    }
}
