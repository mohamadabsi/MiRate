using Framework.Core.Base;
using Framework.Core.Contracts.Notifications;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Core.Contracts
{
    public interface INotificationsManager
    {

        Task<IPagedList<NotificationQueueVM>> GetPagedListNotificationQueue(NotificationFilter filter);

        Task AddNotificationEmailToQueueAsync(string templateName, Dictionary<string, string> placeHolders, List<string> to,
            List<string> cc = null, List<string> bcc = null, Guid? attachmentId = null ,bool isImmediate = false);

        Task AddNotificationSMSToQueueAsync(string templateName, Dictionary<string, string> placeHolders, List<string> to , bool isImmediate = false);
        List<LookupVM> getAllSubject();

        Task<IPagedList<NotificationQueueVM>> GetPagedListNotificationQueueSort(NotificationFilter filter);
    }
}
