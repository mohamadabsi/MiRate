using Framework.Core.Base;
using Framework.Core.Data;

namespace Framework.Core.CommonTables.Entities
{
    public class Application : LookupEntityBase<int>
    {
        public string Code { get; set; }
    }
}
