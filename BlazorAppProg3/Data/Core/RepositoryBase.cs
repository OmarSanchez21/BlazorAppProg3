using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorAppProg3.Data.Core
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly Context contexto;
        private DbSet<TEntity> contextoDbSet;
        public RepositoryBase(Context _contexto)
        {
            this.contexto = _contexto;
            this.contextoDbSet = this.contexto.Set<TEntity>();
        }
        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.contextoDbSet.Any(filter);
        }

        public virtual List<TEntity> GetAll()
        {
            return this.contextoDbSet.ToList();
        }

        public virtual TEntity GetEntity(int predicate)
        {
            return contextoDbSet.Find(predicate);
        }

        public virtual TEntity GetEntityByEmail(string email)
        {
            return contextoDbSet.Find(email);
        }

        public virtual void Remove(TEntity entity)
        {
            this.contextoDbSet.Update(entity);
        }

        public virtual void Remove(TEntity[] entities)
        {
            this.contextoDbSet.UpdateRange(entities);
        }

        public virtual void Save(TEntity entity)
        {
            this.contextoDbSet.Add(entity);
        }

        public virtual void Save(TEntity[] entities)
        {
            this.contexto.AddRange(entities);
        }

        public virtual void SaveChanges()
        {
            this.contexto.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            this.contextoDbSet.Update(entity);
        }

        public virtual void Update(TEntity[] entities)
        {
            this.contextoDbSet.UpdateRange(entities);
        }
    }
}
