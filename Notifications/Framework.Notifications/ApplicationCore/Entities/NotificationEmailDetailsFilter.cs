using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Base;
using System.ComponentModel.DataAnnotations;
using Framework.Notifications.Resources;

namespace Framework.Notifications.Entities
{
    public class NotificationEmailDetailsFilter : FilterBase
    {
        [Display(ResourceType = typeof(NotificationsResources), Name = nameof(NotificationsResources.Subject))]
        public string Subject { get; set; }
        [Display(ResourceType = typeof(NotificationsResources), Name = nameof(NotificationsResources.EmailToAddress))]
        public string To { get; set; }
        [Display(ResourceType = typeof(NotificationsResources), Name = nameof(NotificationsResources.EmailFromAddress))]
        public string EmailFromAddress { get; set; }
        [Display(ResourceType = typeof(NotificationsResources), Name = nameof(NotificationsResources.EmailFromName))]
        public string EmailFromName { get; set; }

        [Display(ResourceType = typeof(NotificationsResources), Name = nameof(NotificationsResources.LastSendDateAfter))]
        public DateTime? LastSendDateAfter { get; set; }

        [Display(ResourceType = typeof(NotificationsResources), Name = nameof(NotificationsResources.LastSendDateBefore))]
        public DateTime? LastSendDateBefore { get; set; }

        [Display(ResourceType = typeof(NotificationsResources), Name = nameof(NotificationsResources.LastSendDate))]
        public DateTime? LastSendDate { get; set; }
    }
}
