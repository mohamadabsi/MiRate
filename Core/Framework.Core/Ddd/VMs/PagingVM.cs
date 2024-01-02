using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

namespace Framework.Core.Ddd.VMs
{
    public abstract class PagingVM
    {
        public StaticPagedList<object> Items { get; set; }

        [HiddenInput]
        public int PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 10;        

        public bool IsExport { get; set; }
        [HiddenInput]
        public bool IsDescending { get; set; } = true;

        public string ReturnUrl { get; set; }

    }
}
