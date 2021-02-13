using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class, IEntity, new()
        where TContext:DbContext, new()
    {
        public void Add(TEntity Entity)
        {
            using (TContext reCapContext = new TContext())
            {
                var addedEntity = reCapContext.Entry(Entity);
                addedEntity.State = EntityState.Added;
                reCapContext.SaveChanges();
            }
        }

        public void Delete(TEntity Entity)
        {
            using (TContext reCapContext = new TContext())
            {
                var deletedEntity = reCapContext.Entry(Entity);
                deletedEntity.State = EntityState.Deleted;
                reCapContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext reCapContext = new TContext())
            {
                return reCapContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext reCapcontext = new TContext())
            {
                return filter == null ? reCapcontext.Set<TEntity>().ToList()
                    : reCapcontext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity Entity)
        {
            using (TContext reCapContext = new TContext())
            {
                var updatedEntity = reCapContext.Entry(Entity);
                updatedEntity.State = EntityState.Modified;
                reCapContext.SaveChanges();
            }
        }
    }
}
