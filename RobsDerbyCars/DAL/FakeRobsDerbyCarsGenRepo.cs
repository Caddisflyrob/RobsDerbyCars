using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using RobsDerbyCars.Models;



namespace RobsDerbyCars.DAL
{
    public class FakeRobsDerbyCarsGenRepo<TEntity> : IDerbyCars<TEntity> where TEntity : class
    {
        List<TEntity> entities;

        public FakeRobsDerbyCarsGenRepo(List<TEntity> entitiesList)
        {
            entities = entitiesList;
        }

        public IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            var query = entities.AsQueryable<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        

        public virtual void Insert(TEntity entity)
        {
            entities.Add(entity);
        }

        //public virtual void Delete(object id)
        //{

        //    TEntity entityToDelete = GetByID(id);
        //    Delete(entityToDelete);
        //}

        public virtual void Delete(TEntity entityToDelete)
        {
   
            entities.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            // TODO: simulate Attach and state
            // Or not: We probably won't need to simulate state
            /* dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            */
        }
    }
}
