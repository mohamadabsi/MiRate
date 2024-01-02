//add-migration -context NotificationsDbContext "Notifications_FixTemplates" -o ./Infrastructure/Data/Migrations
using Framework.Core.Contracts;
using Framework.Core.Data;
using Framework.Core.Data.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Framework.Notifications.Data
{
    public class NotificationsDbContext : EfCoreDbContext<NotificationsDbContext>, INotificationsDbContext
    {
        public NotificationsDbContext(DbContextOptions<NotificationsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.ApplyCommonSettings(modelBuilder);

            //dynamically load all entity and query type configurations
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                (type.BaseType?.IsGenericType ?? false)
                && (type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)));

            foreach (var typeConfiguration in typeConfigurations)
            {
                var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);

                configuration.ApplyConfiguration(modelBuilder);
            }

            base.ApplyCascadeSettings(modelBuilder);

            base.OnModelCreating(modelBuilder);


        }
    }
}
