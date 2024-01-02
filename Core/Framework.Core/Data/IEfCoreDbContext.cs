using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Core.Data
{
    public interface IEfCoreDbContext 
    {

        int SaveChanges(string userName="");
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default,string userName="");

        DbSet<T> Set<T>() where T : class;

        EntityEntry<TEntity> Attach<TEntity>([NotNull] TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Update<TEntity>([NotNull] TEntity entity) where TEntity : class;
        Task SaveChangesWithAuditAsync(CancellationToken cancellationToken = default, string userName = "");
        void SaveChangesWithAudit(CancellationToken cancellationToken = default, string userName = "");


    }
}
