using Hangfire;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Framework.Core.Extensions;

namespace Framework.Core.BackgroundJobs
{

    public static class BackGroundJobExtension
    {

        public static void RegisterBackGroundJobs(this IApplicationBuilder app,
                                                  List<Assembly> assemblies,
                                                  IServiceProvider serviceProvider,
                                                  bool registerBackGroundJobs)
        {
            if (registerBackGroundJobs)
            {
                app.UseHangfireDashboard("/hangfire",
                    new DashboardOptions
                    {
                        Authorization = new[] { new HangfireDashboardAuthFilter() }
                    });
            }
            app.UseHangfireServer();

            if (registerBackGroundJobs)
            {
                foreach (var assembly in assemblies)
                {

                    foreach (Type mytype in assembly.GetTypes()
                                                    .Where(mytype => mytype.GetInterfaces()
                                                    .Contains(typeof(IBackGroundJob))))
                    {

                        IBackGroundJob backGroundJob = (IBackGroundJob)Activator.CreateInstance(mytype, serviceProvider);

                        RecurringJob.AddOrUpdate(() => backGroundJob.Execute(), backGroundJob.CronExpression);

                    }
                }
            }
        }
        public static void AddBackGroundJobs(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
 
            if (configuration.MockDataBase())
            {
                services.AddHangfire(config =>
                {
                    config.UseMemoryStorage();
                });
            }
            else
            {
                var conn = configuration.GetConnectionString("CommonConnection");

                services.AddHangfire(x => x.UseSqlServerStorage(conn));
            }

        }
        public static T GetService<T>(this IServiceProvider serviceProvider)
        {
            var instance = (T)serviceProvider.GetService(typeof(T));

            return instance;
        }
    }
}
