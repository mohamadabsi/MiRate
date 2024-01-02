using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Framework.Notifications.Entities;

namespace Framework.Notifications.Mapping
{
   public class NotificationsMapper: Profile
    {
        public NotificationsMapper()
        {
            this.CreateMap<NotificationEmailDetails, NotificationEmailDetailsVM>().ReverseMap();
        }
    }
}
