using AutoMapper;
using Framework.Core.Contracts.Notifications;
using Framework.Notifications.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Notifications.ApplicationCore.Services
{
    public class NotificationsAutoMapper : Profile
    {
        public NotificationsAutoMapper()
        {
            this.CreateMap<NotificationQueue, NotificationQueueVM>().ReverseMap();
        }
    }
}
