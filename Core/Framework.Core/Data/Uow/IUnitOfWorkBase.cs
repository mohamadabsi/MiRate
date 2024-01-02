using System.Threading.Tasks;

namespace Framework.Core.Data.Uow
{

    public interface IUnitOfWorkBase<TContext> where TContext : IEfCoreDbContext
    {
        // TContext Context { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();

    }


}
