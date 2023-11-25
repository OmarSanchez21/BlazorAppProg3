using System.Linq.Expressions;

namespace BlazorAppProg3.Data.Core
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Save(TEntity[] entities);
        void Update(TEntity entity);
        void Update(TEntity[] entities);
        void Remove(TEntity entity);
        void Remove(TEntity[] entities);
        TEntity GetEntity(int predicate);
        TEntity GetEntityByEmail(string email);
        List<TEntity> GetAll();
        bool Exists(Expression<Func<TEntity, bool>> filter);
        void SaveChanges();
    }
}
