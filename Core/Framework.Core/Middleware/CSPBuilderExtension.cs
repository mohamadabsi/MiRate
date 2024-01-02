 
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Framework.Core.Middleware
{
     public static class CSPServiceSetting
    {
        public static void AddCSPServiceSettings(this IServiceCollection services)
        {
            //services.AddCsp(nonceByteAmount: 32);
            //  services.AddScoped<ICspNonceService, CustomCspNonceService>();
            //services.AddSingleton<ICspNonceService>(svcProvider => new CspNonceService(nonceByteAmount: 32));
        }
    }

    //public class CustomCspNonceService : ICspNonceService
    //{
    //    private readonly string _nonce;

    //    private readonly IHttpContextAccessor httpContextAccessor;
    //    public CustomCspNonceService(IHttpContextAccessor httpContextAccessor)
    //    {
    //        this.httpContextAccessor = httpContextAccessor;
    //        if (this.httpContextAccessor.HttpContext.Request.Cookies["NCookie"] != null)
    //        {
    //            _nonce = this.httpContextAccessor.HttpContext.Request.Cookies["NCookie"].ToString();
    //        }
    //        else
    //        {
    //            byte[] nonceBytes = new byte[32];
    //            using (var rng = RandomNumberGenerator.Create())
    //            {
    //                rng.GetBytes(nonceBytes);
    //            }
    //            _nonce = Convert.ToBase64String(nonceBytes);

    //            this.httpContextAccessor.HttpContext.Response.Cookies.Append("NCookie", _nonce, new CookieOptions() { HttpOnly = true, IsEssential = true });
    //        }
    //    }
    //    public string GetNonce()
    //    {
    //        return _nonce;
    //    }
    //}
}

namespace Joonasw.AspNetCore.SecurityHeaders.XContentTypeOptions
    {
        public class XContentTypeOptionsMiddleware
        {
            private const string HeaderName = "X-Content-Type-Options";
            private readonly RequestDelegate _next;
            private readonly string _headerValue;


        public XContentTypeOptionsMiddleware(RequestDelegate next   )
        {
            _next = next;
            _headerValue =   "nosniff";
        }
        //public XContentTypeOptionsMiddleware(RequestDelegate next, IOptions<XContentTypeOptionsOptions> options)
        //    {
        //        _next = next;
        //        _headerValue = options.Value.AllowSniffing ? string.Empty : "nosniff";
        //    }

            public async Task Invoke(HttpContext context)
            {
                // Let's just not bother with adding the header if they want to allow sniffing
                if (!string.IsNullOrWhiteSpace(_headerValue) && !ContainsXContentTypeOptionsHeader(context.Response))
                {
                    context.Response.Headers.Add(HeaderName, _headerValue);
                }
                await _next(context);
            }

            private static bool ContainsXContentTypeOptionsHeader(HttpResponse response)
            {
                return response.Headers.Any(h => h.Key.Equals(HeaderName, StringComparison.OrdinalIgnoreCase));
            }
        }
    }


    namespace Joonasw.AspNetCore.SecurityHeaders
    {
        public class XContentTypeOptionsOptions
        {
            /// <summary>
            /// Defines the X-Content-Type-Options header with the 'nosniff' option
            /// </summary>
            public XContentTypeOptionsOptions()
                : this(false)
            {

            }

            /// <summary>
            /// Defines the X-Content-Type-Options header and whether to allow sniffing
            /// </summary>
            /// <param name="allowSniffing"></param>
            public XContentTypeOptionsOptions(bool allowSniffing)
            {
                AllowSniffing = allowSniffing;
            }

            /// <summary>
            /// Gets the value to allow sniffing on your site
            /// </summary>
            public bool AllowSniffing { get; set; }
        }
    }

