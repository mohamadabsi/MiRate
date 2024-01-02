using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core;
using Framework.Notifications.Entities;
using Framework.Notifications.Services;
using Microsoft.AspNetCore.Mvc;

namespace Framework.Notifications.Areas.Notifications.Pages.Components.ReSendMessageViewComponent
{
    public class ReSendMessageViewComponent : ViewComponent
    {
        private readonly INotificationEmailDetailsService notificationEmailDetailsService;

        public ReSendMessageViewComponent(INotificationEmailDetailsService notificationEmailDetailsService)
        {
            this.notificationEmailDetailsService = notificationEmailDetailsService;
        }

        public IViewComponentResult Invoke(Guid notificationEmailId, ViewModes viewMode)
        {            
            var notification = notificationEmailDetailsService.GetNotificationEmailDetailsById(notificationEmailId);
            notification.Id = notificationEmailId;
            return View(viewMode.ToString(), notification);
        }
    }
}
