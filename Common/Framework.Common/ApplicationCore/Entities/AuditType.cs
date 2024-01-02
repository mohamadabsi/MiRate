using Framework.Core.Base;
using Framework.Core.Data;
using System.Collections.Generic;

namespace Framework.Core.CommonTables.Entities
{
    public class AuditType : LookupEntityBase<int>
    {
        public AuditType()
        {
            Audits = new HashSet<Audit>();
        }

        public int? ApplicationId { get; set; }
        public virtual ICollection<Audit> Audits { get; set; }
    }
}  
