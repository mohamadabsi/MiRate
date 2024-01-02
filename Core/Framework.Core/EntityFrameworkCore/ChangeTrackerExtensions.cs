using Framework.Core.EntityFrameworkCore.TrackEntities;
using Framework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Framework.Core.EntityFrameworkCore
{
    public static class ChangeTrackerExtensions
    {
        public static void SetShadowProperties(this ChangeTracker changeTracker,string userName= "Anonymous")
        {
            changeTracker.DetectChanges();

            var timestamp = DateTime.UtcNow;

            foreach (var entry in changeTracker.Entries())
            {
                if (entry.State == EntityState.Added && entry.Entity is IShadowProperties)
                {
                    entry.Property("CreatedOn").CurrentValue = timestamp;
                    entry.Property("CreatedBy").CurrentValue = userName;
                }

                if (entry.State == EntityState.Modified && entry.Entity is IShadowProperties)
                {
                    entry.Property("UpdatedOn").CurrentValue = timestamp;
                    entry.Property("UpdatedBy").CurrentValue = userName;
                }

                if (entry.State == EntityState.Deleted && entry.Entity is ISoftDelete)
                {
                    entry.State = EntityState.Modified;
                    entry.Property("IsDeleted").CurrentValue = true;
                }

                //Set Guid Id Sequential
                if(entry.Entity.GetType().GetProperty("Id") != null)
                {
                    Guid id;
                    if (Guid.TryParse(entry.Property("Id").CurrentValue.ToString(), out id) && id == Guid.Empty)
                    {
                        entry.Property("Id").CurrentValue = Guid.NewGuid().AsSequentialGuid();
                    }
                }

            }
        }

        public static void Validate(this ChangeTracker changeTracker)
        {
            var validationResults = new List<ValidationResult>();
            foreach (var entry in changeTracker.Entries())
            {
                string validationErrors = null;
                if (!System.ComponentModel.DataAnnotations.Validator.TryValidateObject(entry.Entity, new ValidationContext(entry.Entity), validationResults))
                {
                    foreach (var item in validationResults)
                    {
                        validationErrors +=
                            $"Entity: {entry.Entity} - Property: {item.MemberNames} - Error: {item.ErrorMessage} \n ";
                    }
                    throw new ValidationException(validationErrors);
                }
            }

        }
    }
}
