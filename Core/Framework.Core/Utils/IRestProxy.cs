using System.Threading.Tasks;

namespace Framework.Core.Utils
{
    public class ProxyConfiguration
    {
        public string ApiBaseUrl { get; set; }

        public string ApiUserName { get; set; }

        public string ApiUserPassword { get; set; }

        public string ApiDomain { get; set; }

        public string AuthorizationToken { get; set; }

        public string AuthorizationTokenKey { get; set; }

        public string AuthorizationTokenValue { get; set; }

        public bool EnableCaching { get; set; }

        public AuthenticationTypes AuthenticationType { get; set; }

        public string Authority { get;  set; }

        public string ClientId { get;  set; }

        public string ClientSecret { get;  set; }

        public string RedirectUri { get;  set; }
        public string SessionClaimName { get; set; }
    }


    public interface IRestProxy
    {
        void InitializeConfiguration(string sectioncode);

        ProxyConfiguration Config { get; set; }
      
        string ResourcesUrl { get; set; }

        Task<R> Get<R>(string url);

        Task<R> GetRegions<R>(string url);

        Task<R> GetById<R>(string id, string url);

        Task Delete(string url);

        Task<R> Update<R, T>(T input, string url);

        Task<R> Post<R, T>(T input, string url);
    }

    public enum AuthenticationTypes
    {
        Basic = 100,
        Bearer = 200
    }

}
