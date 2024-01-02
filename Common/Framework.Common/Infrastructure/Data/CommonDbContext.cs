//add-migration -context CommonDbContext "Common_SetUrls"    -o ./Infrastructure/Data/Migrations
using Framework.Core.CommonTables.Entities;
using Framework.Core.Contracts;
using Framework.Core.Data;
using Framework.Core.Data.Mapping;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Data
{
    public class CommonDbContext :  EfCoreDbContext<CommonDbContext>, ICommonDbContext
    {
        public CommonDbContext(DbContextOptions<CommonDbContext> options) :base(options)
        {
          
        }

        public DbSet<SystemSetting> SystemSetting { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

    public interface ICommonDbContext: IEfCoreDbContext
    {

    }


}
