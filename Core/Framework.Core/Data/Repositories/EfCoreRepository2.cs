using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Framework.Core.Data.Repositories
{
    public class EfCoreRepository2<TContext, TEntity> : IEfCoreRepository2<TContext, TEntity>
    where TContext : DbContext
    where TEntity : class
    {
        public TContext DbContext
        {
            get
            {
                if (this.dbContext != null)
                    return this.dbContext;

                this.dbContext = this.DbContextFactory.CreateDbContext();

                return dbContext;
            }
        }
        private TContext dbContext { get; set; }
        private IDbContextFactory<TContext> DbContextFactory { get; }

        protected DbSet<TEntity> DbSet { get; }


        public EfCoreRepository2(IDbContextFactory<TContext> dbContextFactory)
        {
            this.DbContextFactory = dbContextFactory;
            this.DbSet = this.DbContext.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Table => DbSet;

        public virtual IQueryable<TEntity> TableNoTracking => DbSet.AsNoTracking();

        public TEntity Insert(TEntity entity, bool autoSave = false)
        {
            var savedEntity = DbSet.Add(entity).Entity;

            if (autoSave)
            {

                DbContext.ChangeTracker.SetShadowProperties("");

                DbContext.ChangeTracker.Validate();

                DbContext.SaveChanges();
            }

            return savedEntity;
        }

        public void Insert(IEnumerable<TEntity> entities, bool autoSave = false)
        {
            DbSet.AddRange(entities);

            if (autoSave)
            {
                DbContext.SaveChanges();
            }
        }

        public async Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, string userName = "")
        {
            var savedEntity = DbSet.Add(entity).Entity;
            if (autoSave)
            {
                await DbContext.SaveChangesAsync();
                // await DbContext.SaveChangesAsync(userName:userName);
            }
            return savedEntity;
        }

        public TEntity Update(TEntity entity, bool autoSave = false)
        {
            DbContext.Attach(entity);

            var updatedEntity = DbContext.Update(entity).Entity;

            if (autoSave)
            {
                DbContext.SaveChanges();
            }

            return updatedEntity;
        }

        public void Update(IEnumerable<TEntity> entities, bool autoSave = false)
        {
            DbSet.UpdateRange(entities);
            if (autoSave)
            {
                DbContext.SaveChanges();
            }
        }


        public async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, string userName = "")
        {
            DbContext.Attach(entity);

            var updatedEntity = DbContext.Update(entity).Entity;

            if (autoSave)
            {
                await DbContext.SaveChangesAsync();
                //await DbContext.SaveChangesAsync(userName:userName);
            }

            return updatedEntity;
        }

        public void Delete(TEntity entity, bool autoSave = false)
        {
            DbSet.Remove(entity);

            if (autoSave)
            {
                DbContext.SaveChanges();
            }
        }

        public async Task DeleteAsync(TEntity entity, bool autoSave = false)
        {
            DbSet.Remove(entity);

            if (autoSave)
            {
                await DbContext.SaveChangesAsync();
            }
        }

        public long GetCount()
        {
            return DbSet.LongCount();
        }

        public async Task<long> GetCountAsync()
        {
            return await DbSet.LongCountAsync();
        }

        protected IQueryable<TEntity> GetQueryable()
        {
            return DbSet.AsQueryable();
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate, bool autoSave = false)
        {
            foreach (var entity in GetQueryable().Where(predicate).ToList())
            {
                Delete(entity, autoSave);
            }

            if (autoSave)
            {
                DbContext.SaveChanges();
            }
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false)
        {
            var entities = await GetQueryable()
                .Where(predicate)
                .ToListAsync();

            foreach (var entity in entities)
            {
                DbSet.Remove(entity);
            }

            if (autoSave)
            {
                await DbContext.SaveChangesAsync();
            }
        }


        public virtual PagedList<TEntity> GetWithPagination(int pageNumber, int pageSize, out int totalCount,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            Expression<Func<TEntity, bool>> filter = null,
          string includeProperties = "")
        {
            var query = TableNoTracking;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            totalCount = query.Count();
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);

            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            else
            {
                throw new Exception();
            }
            return new PagedList<TEntity>(query, pageNumber, pageSize);
        }

        public virtual PagedList<TEntity> SearchWithFilters(
    int pageNumber,
    int pageSize,
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
    IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
    params Expression<Func<TEntity, object>>[] includes)
        {
            var query = TableNoTracking;

            if (filters != null && filters.Count() > 0)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            query = query.IncludeMultiple(includes);


            if (orderBy != null)
            {
                query = orderBy(query);
            }
            else
            {
                throw new Exception();
            }

            return new PagedList<TEntity>(query, pageNumber, pageSize);
        }

        public virtual PagedList<TEntity> GetWithPaginationDynamicFilter(int pageNumber, int pageSize,
         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
          IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
         string includeProperties = "")
        {
            var query = TableNoTracking;

            if (filters != null && filters.Count() > 0)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                //if (includeProperty.Contains('.'))
                //{
                //    var props = includeProperty.Split('.');
                //    query = query.Include(props[0]).ThenInclude(props[1]);
                //    continue;
                //}
                query = query.Include(includeProperty);

            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            else
            {
                throw new Exception();
            }

            return new PagedList<TEntity>(query, pageNumber, pageSize);
        }


        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual void Delete(object id, bool autoSave = false)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return;
            }

            Delete(entity, autoSave);
        }

        public virtual async Task DeleteAsync(object id, bool autoSave = false)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return;
            }

            await DeleteAsync(entity, autoSave);
        }

        public Task<PagedList<TEntity>> GetWithPaginationDynamicFilterAsync(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, IEnumerable<Expression<Func<TEntity, bool>>> filters = null, string includeProperties = "")
        {
            var query = TableNoTracking;

            if (filters != null && filters.Count() > 0)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                //if (includeProperty.Contains('.'))
                //{
                //    var props = includeProperty.Split('.');
                //    query = query.Include(props[0]).ThenInclude(props[1]);
                //    continue;
                //}
                query = query.Include(includeProperty);

            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            else
            {
                throw new Exception();
            }

            return Task.FromResult(new PagedList<TEntity>(query, pageNumber, pageSize));
        }
    }

}



