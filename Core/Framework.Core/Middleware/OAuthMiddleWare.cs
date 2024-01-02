using Framework.Core.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Threading.Tasks;

namespace Framework.Core.Middleware

{
    public static class OAuthMiddleWare
    {
        public static void UseOAuth(this IServiceCollection services, IConfiguration configuration,string sectionName)
        {
            var section = configuration.GetSection(sectionName);

            var config = section.Get<ProxyConfiguration>();

            var authority = config.Authority;

            var clientId = config.ClientId;

            var clientSecret = config.ClientSecret;

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = "Cookies";
                options.RequireAuthenticatedSignIn = false;
            })
            .AddCookie()
            .AddOpenIdConnect(options =>
            {
                options.Authority = authority;
                options.RequireHttpsMetadata = false;
                options.ClientId = clientId;
                options.ClientSecret = clientSecret;
                options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                options.SaveTokens = true;
                options.RequireHttpsMetadata = false;
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Events = new OpenIdConnectEvents
                {
                    OnRedirectToIdentityProvider = async ctx =>
                    {
                        ctx.ProtocolMessage.RedirectUri = config.RedirectUri;
                        await Task.FromResult(0);
                    },
                    OnAccessDenied = context =>
                    {
                        context.HandleResponse();
                        context.Response.Redirect("/home");
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        context.HandleResponse();
                        context.Response.Redirect("/error");
                        return Task.CompletedTask;
                    },
                    OnRemoteFailure = context =>
                    {
                        context.HandleResponse();
                        context.Response.Redirect("/error");
                        return Task.CompletedTask;
                    },

                };
            });

            services.AddHttpClient();

        }

    }
}
