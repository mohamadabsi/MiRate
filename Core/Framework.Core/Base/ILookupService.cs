using Framework.Core.Base;
using System;
using System.Collections.Generic;

namespace Framework.Core.Base
{
    public interface ILookupService: IApplicationServiceBase
    {
         List<LookupVM> GetLookup(string lookupType);
    }
}
