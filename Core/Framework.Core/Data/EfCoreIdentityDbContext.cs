using Framework.Core.Base;
using Framework.Core.Extensions;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Core.Data
{
    public abstract class EfCoreIdentityDbContext<TContext> : DbContext, IEfCoreDbContext
        where TContext : DbContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        protected EfCoreIdentityDbContext(DbContextOptions<TContext> options,
            IHttpContextAccessor httpContextAccessor) : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int SaveChanges(string userName = "")
        {
            try
            {
              
                var currentUserName = httpContextAccessor?.HttpContext?.User?.Identity?.Name?.ToLower();

                currentUserName = currentUserName.IsNotNullOrEmpty() ? currentUserName : userName;

                ChangeTracker.SetShadowProperties(currentUserName);

                ChangeTracker.Validate();

                return base.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                ChangeTracker.AutoDetectChangesEnabled = true;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default, string userName = "")
        {
            try
            {
               
                var currentUserName = httpContextAccessor?.HttpContext?.User?.Identity?.Name?.ToLower();

                currentUserName = currentUserName.IsNotNullOrEmpty() ? currentUserName : userName;

                ChangeTracker.SetShadowProperties(currentUserName);

                ChangeTracker.Validate();

                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        public void ApplyCommonSettings(ModelBuilder modelBuilder)
        {

            foreach (var property in modelBuilder.Model.GetEntityTypes()
          .SelectMany(t => t.GetProperties())
          .Where(p => p.ClrType == typeof(decimal)))
            {
                property.SetColumnType("decimal(18, 6)");
            }

            foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(DateTime)))
            {
                property.SetColumnType("datetime2");
            }
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(t => t.GetProperties())
                    .Where(p => p.ClrType == typeof(string) && (p.Name.Contains("Description") ||
                    p.Name.Contains("Comment") || p.Name.Contains("Note"))))
            {
                if (property.GetMaxLength() == null)
                    property.SetMaxLength(1000);
            }
            foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(string)))
            {
                if (property.GetMaxLength() == null)
                    property.SetMaxLength(250);
            }

            foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(Guid) && p.Name == "Id"))
            {
                property.SetDefaultValueSql("newsequentialid()");
            }
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .Where(e => e.ClrType.BaseType == typeof(LookupEntityBase))
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(int) && p.Name == "Id"))
            {
                property.SetValueGenerationStrategy(
                   SqlServerValueGenerationStrategy.SequenceHiLo);
            }


            foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.Name == "CreatedOn"))
            {
                property.SetDefaultValueSql("getDate()");
            }

            modelBuilder.ApplyGlobalFilters<EntityBase>(e => e.IsDeleted == false);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        public void ApplyCascadeSettings(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }
        }
        /// <summary>
        /// Modify the input SQL query by adding passed parameters
        /// </summary>
        /// <param name="sql">The raw SQL query</param>
        /// <param name="parameters">The values to be assigned to parameters</param>
        /// <returns>Modified raw SQL query</returns>
        protected virtual string CreateSqlWithParameters(string sql, params object[] parameters)
        {
            //add parameters to sql
            for (var i = 0; i <= (parameters?.Length ?? 0) - 1; i++)
            {
                if (!(parameters[i] is DbParameter parameter))
                    continue;

                sql = $"{sql}{(i > 0 ? "," : string.Empty)} @{parameter.ParameterName}";

                //whether parameter is output
                if (parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Output)
                    sql = $"{sql} output";
            }

            return sql;
        }

        public Task SaveChangesWithAuditAsync(CancellationToken cancellationToken = default, string userName = "")
        {
            throw new NotImplementedException();
        }
        public void SaveChangesWithAudit(CancellationToken cancellationToken = default, string userName = "")
        {
            throw new NotImplementedException();
        }
    }
}
