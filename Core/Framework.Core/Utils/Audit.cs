using Framework.Core.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Utils
{
    public class Audit : FullAuditedEntityBase<Guid>
    {
        public string CrudOperation { get; set; } = "";
        public string TableName { get; set; } = "";
        public string KeyValues { get; set; } = "";
        public string OldValues { get; set; } = ""; 
        public string NewValues { get; set; } = "";
    }

    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }

        public EntityEntry Entry { get; }
        public string TableName { get; set; }
        public string CrudOperation { get; set; }
        public string CreatedBy { get; set; }

        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public Audit ToAudit()
        {





            var audit = new Audit
            {
                TableName = TableName,
                CrudOperation = CrudOperation,
                CreatedBy = CreatedBy,
                CreatedOn = DateTime.UtcNow,
                KeyValues = JsonConvert.SerializeObject(KeyValues),
                OldValues = OldValues.Count == 0 ? "" : JsonConvert.SerializeObject(OldValues),
                NewValues = NewValues.Count == 0 ? "" : JsonConvert.SerializeObject(NewValues)
            };
            return audit;
        }
    }

}

