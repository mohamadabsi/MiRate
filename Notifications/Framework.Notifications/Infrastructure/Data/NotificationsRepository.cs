using Framework.Core.Data;
using Framework.Core.Data.Repositories;
using Framework.Notifications.Data;

namespace Framework.Notifications.Data
{
      public class NotificationsRepository<TEntity> : EfCoreRepository<INotificationsDbContext, TEntity>, INotificationsRepository<TEntity>
        where TEntity : class
    {
        public NotificationsRepository(INotificationsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
     

