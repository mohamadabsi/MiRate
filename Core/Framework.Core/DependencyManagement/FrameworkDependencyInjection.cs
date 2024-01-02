using AutoMapper;
using FluentValidation.AspNetCore;
using Framework.Core.AutoMapper; 
using Framework.Core.Utils;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using NUglify.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Framework.Core.DependencyManagement
{
    public static class FrameworkDependencyInjection
    {
        readonly static string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public static void AddFrameWorkCore(this IServiceCollection services, IConfiguration configuration, List<Assembly> assemblies)
        {
            //services.AddAntiforgery(opts =>
            //{
            //    opts.Cookie.Name = "tmpAFKey";
            //    opts.Cookie.HttpOnly = true;
            //    opts.Cookie.SecurePolicy = HostingEnvironment.EnvironmentName == "Development"
            //? CookieSecurePolicy.SameAsRequest
            //: CookieSecurePolicy.SameAsRequest;
            //});


            services.AddScoped<IDateTimeHelper,DateTimeHelper2>();

            // services.AddCSPServiceSettings();            
            services.AddDistributedMemoryCache();


            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = 2000; // 2000 items max
                options.ValueLengthLimit = 1024 * 1024 * 100; // 100MB max len form data
            });

            //   services.AddScoped<ICachingService, CachingService>();

           // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

           // services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            //services.AddScoped<IUrlHelper>(x =>
            //{
            //    var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
            //    var factory = x.GetRequiredService<IUrlHelperFactory>();
            //    return factory.GetUrlHelper(actionContext);
            //});

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                // enables immediate logout, after updating the user's stat.
                options.ValidationInterval = TimeSpan.Zero;
            });

            var defaultCulture = new RequestCulture("en-GB", "en-GB");

            defaultCulture.Culture.DateTimeFormat.DateSeparator = "/";

            services.Configure<RequestLocalizationOptions>(
           opts =>
           {
               var supportedCultures = new List<CultureInfo>{
                    new CultureInfo("en-GB"),
                    new CultureInfo("ar")
               };
               // Formatting numbers, dates, etc.
               opts.SupportedCultures = supportedCultures;
               // UI strings that we have localized.
               opts.SupportedUICultures = supportedCultures;
               opts.DefaultRequestCulture = new RequestCulture(culture: "en-GB", uiCulture: "en-GB");
               opts.RequestCultureProviders.Clear();

           });

            services.AddControllers();

            services.AddAuthorization();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApis", Version = "v1" });
            });

            //services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
            //    options.HttpsPort = 443;
            //});

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin();
                                      builder.WithOrigins("*");
                                      builder.AllowAnyHeader();
                                      builder.AllowAnyMethod();
                                  });
            });

            services.RegisterMapperProfiles(assemblies);

            foreach (var assembly in assemblies)
            {
                services.RegisterAssemblyPublicNonGenericClasses(assembly)
                                   .Where(c => c.Name.EndsWith("Service")
                                   || c.Name.EndsWith("Validator")
                                   || c.Name.EndsWith("Helper")
                                   || c.Name.EndsWith("Manager")
                                   || c.Name.EndsWith("Job")
                                   || c.Name.EndsWith("Proxy"))
                                   .AsPublicImplementedInterfaces();
            }

        }

    }
}
