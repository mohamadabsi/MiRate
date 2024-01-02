using System;
using System.Threading.Tasks;

namespace Framework.Core.EntityFrameworkCore.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        //IEfCoreRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : class, IEntity<TKey>;
        //IEfCoreRepository<TEntity> Repository<TEntity>() where TEntity : class;

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : IEfCoreDbContext
    {
        TContext Context { get; }
    }


}
