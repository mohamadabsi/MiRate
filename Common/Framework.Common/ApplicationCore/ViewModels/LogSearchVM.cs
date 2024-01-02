using Framework.Core.Base;
using Framework.Core.CommonTables.Entities;
using Framework.Core.Ddd.VMs;
using PagedList.Core;
using System;

namespace Framework.Core.CommonTables.VM
{
    public class LogFilter : FilterBase
    {
        public string LogLevel { get; set; }

        public string UserName { get; set; }

        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
 


    }
}
