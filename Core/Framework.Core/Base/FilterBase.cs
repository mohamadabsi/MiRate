using System;

namespace Framework.Core.Base
{
    public class FilterBase
    {
        public string SearchKey { get; set; }
        public bool Spinner { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } =  CommonsSettings.PageSize;
        public string UserName { get; set; }

    }
 
}
