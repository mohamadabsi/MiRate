using Framework.Core.Contracts;
using Framework.Core.Data;
using Framework.Core.Data.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

//add-migration -context AttachmentsDbContext "Attachments_IsSecureInAttahcment"    -o ./Infrastructure/Data/Migrations
namespace Framework.Attachments.Data
{
    public class AttachmentsDbContext : EfCoreDbContext<AttachmentsDbContext>, IAttachmentsDbContext
    {
        public AttachmentsDbContext(DbContextOptions<AttachmentsDbContext> options)
            : base(options)
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
