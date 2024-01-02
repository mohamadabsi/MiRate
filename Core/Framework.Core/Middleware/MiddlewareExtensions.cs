using Framework.Core.BackgroundJobs;
using Framework.Core.Globalization;
using Framework.Core.Middleware.SecurityHeader;
using Framework.Core.Utils;
using Hangfire;
using IdentityModel.Client;
using Joonasw.AspNetCore.SecurityHeaders.XContentTypeOptions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Framework.Core.Middleware
{
    public static class FrameworkCoreMiddleware
    {
        public static void UseCommonStartupMiddleware(this IApplicationBuilder app, IHostEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseLoggerMiddleware();
           // app.UseXContentTypeOptionsMiddleware();
            app.UseSecurityMiddleware(new SecurityHeadersBuilder().AddDefaultSecurePolicy());
            app.UseCookiePolicy();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApis v1"));
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //}

            //app.UseHsts();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            //var defaultCulture = new RequestCulture("en-GB", "en-GB");

            //defaultCulture.Culture.DateTimeFormat.DateSeparator = "/";

            // app.UseRequestLocalization();

            //app.UseAuthentication();

            //app.UseCors("MyAllowSpecificOrigins");

            ////app.UseHttpsRedirection();

            ////app.UseStaticFiles();

      
        }

        public static IApplicationBuilder UseXContentTypeOptionsMiddleware(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
 

            return app.UseMiddleware<XContentTypeOptionsMiddleware>(app);


        }
        public static IApplicationBuilder UseSecurityMiddleware(this IApplicationBuilder app, SecurityHeadersBuilder builder)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return app.UseMiddleware<SecurityHeadersMiddleware>(builder.Build());


        }
        public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggerMiddleware>(app);
        }

  

        public static void UseRequestLocalization(this IApplicationBuilder app, IConfiguration Configuration)
        {
            var cultures = Configuration.GetSection("Cultures")
                .GetChildren().ToDictionary(x => x.Key, x => x.Value);

            var cookieProvider = new CookieRequestCultureProvider()
            {
                CookieName = CultureHelper.CultureCookieName
            };

            var supportedCultures = cultures.Keys.ToArray();

            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(supportedCultures[1])
                .AddSupportedCultures(supportedCultures[1])
                .AddSupportedUICultures(supportedCultures);

                localizationOptions.RequestCultureProviders.Insert(0,cookieProvider);
             
            app.UseRequestLocalization(localizationOptions);
        }
 
    }

}
