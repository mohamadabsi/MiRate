using Framework.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Contracts.Notifications
{
   public class NotificationFilter : FilterBase
    {
        public string Subject { get; set; }

        public string To { get; set; }

        public int? NotificationTypeId { get; set; }

        public DateTime? SendDateFrom { get; set; }
        public DateTime? SendDateTo { get; set; }

        public bool IsDeccending { get; set; }
        public string ColName { get; set; } = null;

    }
}
