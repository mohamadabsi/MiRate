using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Framework.Notifications.Entities;
using PagedList.Core;

namespace Framework.Notifications.Services
{
   public interface INotificationEmailDetailsService
    {
        IPagedList<NotificationEmailDetailsVM> GetAllNotificationEmailDetails(NotificationEmailDetailsFilter filter);
        NotificationEmailDetailsVM GetNotificationEmailDetailsById(Guid notificationEmailId);

         Task ReSendEmailAsync(Guid id);
    }
}
