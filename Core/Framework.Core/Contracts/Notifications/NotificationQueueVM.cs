using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Contracts.Notifications
{
    public class NotificationQueueVM
    {
        public string Subject { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Message { get; set; }
        public string LocalizedNotificationTypeName { get; set; }
        public int NotificationTypeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastSendDate { get; set; }

    }

    
}
