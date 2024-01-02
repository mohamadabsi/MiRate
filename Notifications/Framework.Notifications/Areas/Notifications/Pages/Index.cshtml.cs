using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core;
using Framework.Notifications.Entities;
using Framework.Notifications.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PagedList.Core;

namespace Framework.Notifications.Areas.Notifications.Pages
{
    public class IndexModel //: PageModelBase
    {
        private readonly INotificationEmailDetailsService notificationEmailDetailsService;

        [BindProperty(SupportsGet =true)]  
        public NotificationEmailDetailsFilter Filter { get; set; }

        public IPagedList<NotificationEmailDetailsVM> NotificationEmailDetail { get; set; }

        // public IndexModel(INotificationEmailDetailsService notificationEmailDetailsService,
        //                   IAlertManager alertManager,
        //                   IConfiguration configuration ) : base(alertManager, configuration)
        
        // {
        //     this.notificationEmailDetailsService = notificationEmailDetailsService;
        // }

        public void OnGet()
        {
            NotificationEmailDetail = this.notificationEmailDetailsService.GetAllNotificationEmailDetails(this.Filter);
        }

        public IActionResult OnGetReSendMessage(Guid notificationEmailId, ViewModes viewMode)
        {
            return null;//  ViewComponent("ReSendMessage", new { notificationEmailId, viewMode });
        }

        // public IActionResult OnPost(NotificationEmailDetailsVM notificationEmailDetails)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         this.notificationEmailDetailsService.ReSendEmailAsync(notificationEmailDetails.Id);
        //         return Created();
        //     }
        //     return BadRequest();
        // }

    }
}
