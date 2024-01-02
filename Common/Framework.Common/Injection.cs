using Framework.Common.Services;
using Framework.Core.Contracts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Framework.Common
{
    public static class Injections
    {
        public static void AddCommonDB(this IServiceCollection services,
                                       IConfiguration configuration,
                                       IHostEnvironment environment)
        {
            services.AddScoped<IAppSettingsService, AppSettingsService>();

            var connectioon = configuration.GetConnectionString("CommonConnection");

            services.AddDbContext<CommonDbContext>(options =>
            {
                options.UseSqlServer(connectioon);

                if (environment.IsDevelopment())
                    options.EnableSensitiveDataLogging();

            });

            services.AddDbContextFactory<CommonDbContext>(b =>
            {
                b.UseSqlServer(connectioon);

                if (environment.IsDevelopment())
                    b.EnableSensitiveDataLogging();
            }, ServiceLifetime.Scoped);

            services.AddScoped(typeof(CommonRepository<>));
        }

    }
}
