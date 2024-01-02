using System;
using Framework.Core.Data.Uow;
using Microsoft.EntityFrameworkCore;

namespace Framework.Notifications.Data
{

    public interface INotificationsUnitOfWork : IUnitOfWorkBase<INotificationsDbContext>
    {


    }
}
