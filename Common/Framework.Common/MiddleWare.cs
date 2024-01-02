using Framework.Core.Extensions;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Framework.Common
{
    public static class MiddleWare
    {



        //            services.UseDatabase<WFDbContext>(configuration, environment, "WorkFlowConnection");

        //            services.AddScoped(typeof(IUnitOfWorkBase<>), typeof(UnitOfWorkBase<>));

        //            services.AddScoped<IWFUnitOfWork, WFUnitOfWork>();

        //            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        //            services.AddScoped(typeof(IEfCoreRepository<,>), typeof(EfCoreRepository<,>));

        //            services.AddTransient(typeof(IWFDbContext), typeof(WFDbContext));

        //            services.AddScoped(typeof(IWFRepository<>), typeof(WFRepository<>));


        public static void UseCommons(this IApplicationBuilder app,
                                                IHostEnvironment environment,
                                                IConfiguration configuration,
                                                IServiceProvider serviceProvider)
        {
            if (!configuration.MockDataBase())
            {
                serviceProvider.GetService<IDbContextFactory<CommonDbContext>>().CreateDbContext().Database.Migrate();
            }
        }

    }
}

