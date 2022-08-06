using Core.Core.DataAccess.Abstract;
using Core.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        protected TContext Context { get; }
        public EfEntityRepositoryBase(TContext context)
        {
            Context = context;
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null )
        {
            IQueryable<TEntity> queryable = Query();
            if (include != null) queryable = include(queryable);
            if (filter != null) queryable = queryable.Where(filter);
            if (orderBy != null)
                return  orderBy(queryable).ToList();
            return  queryable.ToList();

        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return  Context.Set<TEntity>().FirstOrDefault(filter);
        }
        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();

        }
        }
    }
