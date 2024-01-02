using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Framework.Core.EntityFrameworkCore.Uow
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IUnitOfWork
        where TContext : IEfCoreDbContext
    {
        private IDbContextTransaction _transaction;
        private IsolationLevel? _isolationLevel;

        public TContext Context { get; }


        public UnitOfWork(TContext context)
        {
            Context = context;
        }


        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Context?.Dispose();
        }


    }
}


