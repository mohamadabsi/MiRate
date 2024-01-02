using Dapper;
using DocumentFormat.OpenXml.Office2013.PowerPoint;
using Framework.Core.Base;
using Framework.Core.Contracts;
using Framework.Core.Extensions;
using Framework.Core.Utils;
using Localization.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Core.Data
{
    public abstract class EfCoreDbContext<TContext> : DbContext, IEfCoreDbContext
        where TContext : DbContext
    {
        private readonly ICurrentUserService currentUserService;
        [Inject]
        public IStringLocalizer<AppResources> AppLocalizer { get; set; }
        [Inject]
        public IConfiguration configuration { get; set; }
        //private readonly DapperContext context;
        protected EfCoreDbContext(DbContextOptions<TContext> options, ICurrentUserService currentUserService) : base(options)
        {
            this.currentUserService = currentUserService;
            //this.context = context;
        }

        protected EfCoreDbContext(DbContextOptions<TContext> options) : base(options)
        {
            //this.context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int SaveChanges(string userName = "")
        {
            try
            {
                var currentUserName = this.currentUserService.CurrentUserName;

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
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default, string userName = null)
        {
            try
            {

                var currentUserName = userName.IsNotNullOrEmpty() ? userName : this.currentUserService.CurrentUserName;

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

                if (!entityType.ClrType.GetInterfaces().Contains(typeof(ICascadeDelete)))
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

        public virtual async Task SaveChangesWithAuditAsync(CancellationToken cancellationToken = default, string userName = null)
        {
            ChangeTracker.SetShadowProperties(userName);
            ChangeTracker.Validate();
            var auditEntries = OnBeforeSaveChanges();

            await SaveChangesAsync();
            await OnAfterSaveChanges(auditEntries);
        }

        public virtual void SaveChangesWithAudit(CancellationToken cancellationToken = default, string userName = null)
        {
            ChangeTracker.SetShadowProperties(userName);
            ChangeTracker.Validate();
            var auditEntries = OnBeforeSaveChanges();

            SaveChanges();
            OnAfterSaveChanges(auditEntries);
        }

        private List<AuditEntry> OnBeforeSaveChanges()
        {

            var currentUserName = this.currentUserService.CurrentUserName;
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Metadata.GetTableName();
                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        // value will be generated by the database, get the value after saving
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            auditEntry.CrudOperation = "Add";
                            break;

                        case EntityState.Deleted:
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.CrudOperation = "Delete";
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                if (property.CurrentValue?.Equals(property.OriginalValue) == false)
                                {
                                    auditEntry.OldValues[propertyName] = property.OriginalValue;
                                    auditEntry.NewValues[propertyName] = property.CurrentValue;
                                }
                            }
                            auditEntry.CrudOperation ="Update";
                            break;
                    }
                    auditEntry.CreatedBy = currentUserName;
                }
            }

            // Save audit entities that have all the modifications
            foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
            {
                //base.Add(auditEntry.ToAudit());
                CreateLogs(auditEntry.ToAudit());
            }

            // keep a list of entries where the value of some properties are unknown at this step
            return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }

        private Task OnAfterSaveChanges(List<AuditEntry> auditEntries)
        {
            var currentUserName = this.currentUserService.CurrentUserName;
            if (auditEntries == null || auditEntries.Count == 0)
                return SaveChangesAsync();

            foreach (var auditEntry in auditEntries)
            {
                // Get the final value of the temporary properties
                foreach (var prop in auditEntry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                    else
                    {
                        auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }

                auditEntry.CreatedBy = currentUserName;
                // Save the Audit entry
                //base.AddAsync(auditEntry.ToAudit());
                CreateLogs(auditEntry.ToAudit());

            }

            return base.SaveChangesAsync();
        }





        public async Task CreateLogs(Audit auditEntry)
        {


            try
            {
                string connectionString = this.Database.GetConnectionString();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spINSERT_audit_record", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CrudOperation", auditEntry.CrudOperation);
                    cmd.Parameters.AddWithValue("@TableName", auditEntry.TableName);
                    cmd.Parameters.AddWithValue("@KeyValues", auditEntry.KeyValues);
                    cmd.Parameters.AddWithValue("@OldValues", auditEntry.OldValues);
                    cmd.Parameters.AddWithValue("@NewValues", auditEntry.NewValues);
                    cmd.Parameters.AddWithValue("@CreatedBy", auditEntry.CreatedBy);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception E)
            {

                throw;
            }

               
            //}
            //catch (Exception e)
            //{

            //    throw;
            //}
        }

    }

    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ApplicationConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }

    //public static class ConnectionString
    //{
    //    private static string cName = "Server=RY0DEVCONSQL1\\TSJILSTG,62537;Initial Catalog=RegTech_STG_Second_DB;integrated security=false;user id=AppTsjilSTG ;password=Q!L$#E*Fdsjvcbfkx125Ui3;MultipleActiveResultSets=true";
    //    public static string CName
    //    {
    //        get => cName;
    //    }
    //}
}
