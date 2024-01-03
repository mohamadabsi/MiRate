using Framework.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiRate.Application
{
    public class TestTable : FullAuditedEntityBase<Guid>
    {
        public string Name { get; set; }
    }
}
