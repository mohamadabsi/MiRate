using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Framework.Core.Data.Repositories
{
    public interface IEfCoreRepository<TContext, TEntity>
        where TContext : IEfCoreDbContext
        where TEntity : class
    {
        TContext DbContext { get; }

        IQueryable<TEntity> Table { get; }

        IQueryable<TEntity> TableNoTracking { get; }


        //================================================================
        //============================ INSERT ============================
        //================================================================
        [NotNull]
        TEntity Insert([NotNull] TEntity entity, bool autoSave = false);
        [NotNull]
        Task<TEntity> InsertAsync([NotNull] TEntity entity, bool autoSave = false, string userName = "");
        void Insert(IEnumerable<TEntity> entities, bool autoSave = false);


        //================================================================
        //============================ UPDATE ============================
        //================================================================

        [NotNull]
        TEntity Update([NotNull] TEntity entity, bool autoSave = false);
        [NotNull]
        Task<TEntity> UpdateAsync([NotNull] TEntity entity, bool autoSave = false, string userName = "");
        void Update(IEnumerable<TEntity> entities, bool autoSave = false);


        //================================================================
        //============================ DELETE ============================
        //================================================================

        void Delete([NotNull] TEntity entity, bool autoSave = false);
        void Delete([NotNull] Expression<Func<TEntity, bool>> predicate, bool autoSave = false);
        Task DeleteAsync([NotNull] TEntity entity, bool autoSave = false);
        Task DeleteAsync([NotNull] Expression<Func<TEntity, bool>> predicate, bool autoSave = false);

        long GetCount();

        Task<long> GetCountAsync();

        PagedList<TEntity> GetWithPagination(int pageNumber, int pageSize, out int totalCount,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "");

        PagedList<TEntity> GetWithPaginationDynamicFilter(int pageNumber, int pageSize,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
            string includeProperties = "");

        Task<PagedList<TEntity>> GetWithPaginationDynamicFilterAsync(int pageNumber, int pageSize,
     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
     IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
     string includeProperties = "");

        PagedList<TEntity> SearchWithFilters(
       int pageNumber,
       int pageSize,
       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
       IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
       params Expression<Func<TEntity, object>>[] includes);

        void Delete(object id, bool autoSave = false);
        Task DeleteAsync(object id, bool autoSave = false);

        [NotNull]
        TEntity GetById(object id);
        [NotNull]
        Task<TEntity> GetByIdAsync(object id);


    }

}
