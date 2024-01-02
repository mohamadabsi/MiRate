using Framework.Core.Data;
using Framework.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Framework.Notifications.Data
{
   public interface INotificationsRepository<TEntity> : IEfCoreRepository<INotificationsDbContext, TEntity> where TEntity :class
    {
    }
}
