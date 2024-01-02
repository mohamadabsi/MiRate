using Framework.Core.Globalization;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Framework.Core.Data
{
    public class BlazorServerAuthStateCache
    {
 
        private ConcurrentDictionary<string, object> Cache
            = new ConcurrentDictionary<string, object>();

        private readonly AuthenticationStateProvider authenticationStateProvider;

        public bool HasSubjectId(string subjectId)
            => Cache.ContainsKey(subjectId);

        public void Add(string subjectId, object user)
        {
            Cache.AddOrUpdate(subjectId, user, (k, v) => user);

            System.Diagnostics.Debug.WriteLine($"Caching sid: {subjectId}");

        }

        public T Get<T>(string subjectId)
        {
            if (string.IsNullOrEmpty(subjectId))
                return default(T);
            Cache.TryGetValue(subjectId, out object data);

            return (T)data;
        }

        public void Remove(string subjectId)
        {
            System.Diagnostics.Debug.WriteLine($"Removing sid: {subjectId}");
            Cache.TryRemove(subjectId, out _);
        }

        public async Task<CurrentUserVM> GetCurrentUser(AuthenticationStateProvider authenticationStateProvider)
        {
            var state = await authenticationStateProvider.GetAuthenticationStateAsync();

            var sid = state.User.Claims
             .Where(c => c.Type.Equals("sid"))
             .Select(c => c.Value)
             .FirstOrDefault();

            var CachedUser = this.Get<CurrentUserVM>(sid);

            return CachedUser;
        }

        public class CurrentUserVM
        {
            public Guid Id  { get; set; }
            public string LName => CultureHelper.IsArabic ? ArabicName : Name;
            public string Name { get; set; }
            public string ArabicName { get; set; }
            public string Email { get; set; }
            public int UserTypeId { get; set; }
            public string UserName { get; set; }
            public string Phone { get; set; }
        }

    }
}
