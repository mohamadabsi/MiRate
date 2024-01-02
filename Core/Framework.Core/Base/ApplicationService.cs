using Framework.Core.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Core.Ddd.Application
{
    public abstract class ApplicationService : IApplicationService
    {
        public ApplicationService()
        {

        }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        //public string CurrentUserName { get; set; }
        //public Guid CurrentUserId { get; set; }
        //public IList<string> CurrentUserRoles { get; set; }

        public string CurrentUserName => _httpContextAccessor?.HttpContext?.User?.Identity?.Name;


        public IList<string> CurrentUserRoles
        {
            get
            {
                var list = new List<string>();
                var user = _httpContextAccessor.HttpContext.User;

                if (user.IsInRole("SystemAdmin"))
                    list.Add("SystemAdmin");

                if (user.IsInRole("Supervisor"))
                    list.Add("Supervisor");

                if (user.IsInRole("User"))
                    list.Add("User");

                if (user.IsInRole("Association"))
                    list.Add("Association");


                if (user.IsInRole("ContentManager"))
                    list.Add("ContentManager");

                 _httpContextAccessor.HttpContext.Items["CurrentUserRoles"] = list;

                return list;
            }
        }
        public Guid? CurrentUserId
        { get; set; }
        //=>
        //    _httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault()?.Value?.To<Guid?>();


        public void Dispose()
        {
            
        }

        //public List<string> GetCurrentUserRoles()
        //{
        //    return new List<string>();// _userManager.GetRolesAsync(CurrentUser).GetAwaiter().GetResult().ToList();
        //}
    }
}