using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Framework.Core.Data;
using Framework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Framework.Core.Data.Uow
{
    public class UnitOfWorkBase<TContext> : IUnitOfWorkBase<TContext>
        where TContext : IEfCoreDbContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public DbContext Context { get; }

        public Guid CurrentUserId { get; set; }
        public string CurrentUserName { get; set; }
        public UnitOfWorkBase(DbContext context, IHttpContextAccessor httpContextAccessor)
        {
            Context = context;
            this.httpContextAccessor = httpContextAccessor;
            CurrentUserName = httpContextAccessor?.HttpContext?.User?.Identity?.Name;
        }
        public UnitOfWorkBase(DbContext context)
        {
            Context = context;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
        ~UnitOfWorkBase()
        {
            this.Dispose(false);
        }

        /// <summary>
        ///     The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
                var dbContext = this.Context;
                dbContext?.Dispose();
            }
        }


        public int Save(string userId = null, bool validateOnSaveEnabled = true)
        {
            this.ValidateEntities();
            this.UpdatePropertiesBeforeSave(userId ?? CurrentUserName);
            return this.Context.SaveChanges();
        }

        private void ValidateEntities()
        {
            var changeTracker = this.Context.ChangeTracker;
            var entities = from entry in changeTracker.Entries()
                           where entry.State == EntityState.Modified || entry.State == EntityState.Added
                           select entry.Entity;

            var validationResults = new List<ValidationResult>();
            foreach (var entity in entities)
            {
                string validationErrors = null;
                if (!System.ComponentModel.DataAnnotations.Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults))
                {
                    var exception = new ValidationException();
                    foreach (var item in validationResults)
                    {
                        validationErrors +=
                            $"Entity: {entity} - Property: {item.MemberNames} - Error: {item.ErrorMessage} \n ";
                    }
                    throw new ValidationException(validationErrors);
                }
            }
        }

        /// <summary>
        /// Updates the properties before save.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        private void UpdatePropertiesBeforeSave(string userId = null)
        {
            UpdateId();
            UpdateIsActive();
            UpdateCreatedOn();
            UpdateCreatedBy(userId);
            UpdateModifiedOn();
            UpdateModifiedBy(userId);
        }

        private void UpdateModifiedBy(string userId)
        {
            const string ModifiedByPropery = "ModeifiedBy";
            if (!string.IsNullOrEmpty(userId))
            {


                IEnumerable<EntityEntry> entitiesWithModifiedBy =
                    this.Context.ChangeTracker.Entries()
                        .Where(
                            e =>
                            e.State == EntityState.Modified && e.Entity.GetType().GetProperty(ModifiedByPropery) != null);
                foreach (EntityEntry entry in entitiesWithModifiedBy)
                {
                    entry.Property(ModifiedByPropery).CurrentValue = userId;
                }
            }
        }

        private void UpdateCreatedBy(string userId)
        {
            const string CreatedByPropery = "CreatedBy";
            if (!string.IsNullOrEmpty(userId))
            {
                IEnumerable<EntityEntry> entitiesWithCreatedBy =
                     this.Context.ChangeTracker.Entries()
                        .Where(
                            e =>
                            e.State == EntityState.Added && e.Entity.GetType().GetProperty(CreatedByPropery) != null);
                foreach (EntityEntry entry in entitiesWithCreatedBy)
                {
                    entry.Property(CreatedByPropery).CurrentValue = userId;
                }


            }
        }



        private void UpdateIsActive()
        {
            const string IsActiveProperty = "IsActive";
            IEnumerable<EntityEntry> entitiesWithIsActive =
              this.Context.ChangeTracker.Entries()
                  .Where(
                      e => e.State == EntityState.Added && e.Entity.GetType().GetProperty(IsActiveProperty) != null &&
                      (e.Entity.GetType().GetProperty(IsActiveProperty).PropertyType == typeof(bool)
                      || e.Entity.GetType().GetProperty(IsActiveProperty).PropertyType == typeof(bool?))
                      );
            foreach (EntityEntry entry in entitiesWithIsActive)
            {
                entry.Property(IsActiveProperty).CurrentValue = true;
                if (entry.Property(IsActiveProperty).CurrentValue == null)
                {
                }
                else
                {
                    entry.Property(IsActiveProperty).CurrentValue = Convert.ToBoolean(entry.Property(IsActiveProperty).CurrentValue);
                }
            }
        }

        private void UpdateModifiedOn()
        {
            const string ModifiedOnPropery = "ModifiedOn";
            IEnumerable<EntityEntry> entitiesWithModifiedOn =
              this.Context.ChangeTracker.Entries()
                  .Where(
                      e => e.State == EntityState.Modified && e.Entity.GetType().GetProperty(ModifiedOnPropery) != null);
            foreach (EntityEntry entry in entitiesWithModifiedOn)
            {
                entry.Property(ModifiedOnPropery).CurrentValue = DateTime.Now;
            }
        }

        private void UpdateCreatedOn()
        {
            const string CreatedOnProperty = "CreatedOn";
            IEnumerable<EntityEntry> entitiesWithCreatedOn =
                this.Context.ChangeTracker.Entries()
                    .Where(
                        e => e.State == EntityState.Added && e.Entity.GetType().GetProperty(CreatedOnProperty) != null);
            foreach (EntityEntry entry in entitiesWithCreatedOn)
            {
                entry.Property(CreatedOnProperty).CurrentValue = DateTime.Now;
            }
        }

        private void UpdateId()
        {
            const string IdPropery = "Id";
            IEnumerable<EntityEntry> entitiesWithId =
                this.Context.ChangeTracker.Entries()
                    .Where(
                        e => e.State == EntityState.Added &&
                        e.Entity.GetType().GetProperty(IdPropery) != null &&
                        (e.Entity.GetType().GetProperty(IdPropery).PropertyType == typeof(Guid)
                        || e.Entity.GetType().GetProperty(IdPropery).PropertyType == typeof(Guid?))
                        );
            foreach (EntityEntry entry in entitiesWithId)
            {
                if (entry.Property(IdPropery).CurrentValue == null)
                {
                    entry.Property(IdPropery).CurrentValue = Guid.NewGuid().AsSequentialGuid();
                }
                else if (Guid.TryParse(entry.Property(IdPropery).CurrentValue.ToString(), out Guid id))
                {
                    entry.Property(IdPropery).CurrentValue = id == Guid.Empty ? Guid.NewGuid().AsSequentialGuid() : id;
                }
                else
                    entry.Property(IdPropery).CurrentValue = Guid.NewGuid().AsSequentialGuid();
            }
        }

    }
}


