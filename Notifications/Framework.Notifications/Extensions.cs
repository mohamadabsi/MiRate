using Framework.Core.CommonTables.Services;
using Framework.Core.Contracts;
using Framework.Core.Data;
using Framework.Core.Data.Repositories;
using Framework.Core.Data.Uow;
using Framework.Core.Notifications;
using Framework.Notifications.Data;
using Framework.Notifications.Infrastructure;
using Framework.Notifications.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Framework.Notifications
{
    public static class NotificationServicesConfigExtension
    {
        public static void AddNotifications (this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
 
            services.UseDatabase<NotificationsDbContext>(configuration, environment, "NotificationConnection");

            services.AddScoped(typeof(IUnitOfWorkBase<>), typeof(UnitOfWorkBase<>));

            services.AddScoped<INotificationsManager, NotificationsManager>();

            services.AddScoped<INotificationsUnitOfWork, NotificationsUnitOfWork>();

            services.AddScoped(typeof(IEfCoreRepository<,>), typeof(EfCoreRepository<,>));

            services.AddScoped(typeof(INotificationsDbContext), typeof(NotificationsDbContext));

            services.AddScoped(typeof(INotificationsRepository<>), typeof(NotificationsRepository<>));
            
            services.AddScoped<INotificationSettingsService,NotificationSettingsService>();

            services.AddScoped<INotificationTemplateService, NotificationTemplateService>();
            
            services.AddScoped<IEmailService, SmtpEmailService>();
            services.AddScoped<IEmailServiceAPI, EmailServiceAPI>();
          
            services.AddScoped<ISmsService, SmsService>();
        
            services.AddScoped<SharedDependency>();

            services.AddScoped<NotificationSettings>();
 
        }
 
        public static void UseNotifications(this IApplicationBuilder app, IHostEnvironment env, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            app.Migrate<NotificationsDbContext>(serviceProvider, configuration, env);
        }
    }
}
