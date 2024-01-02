// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepositoryFactory.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Contracts
{

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The i repo.
    /// </summary>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Gets the application settings service.
        /// </summary>
        IApplicationSettingsService ApplicationSettingsService { get; }

        /// <summary>
        /// Gets the caching service.
        /// </summary>
        ICachingService CachingService { get; }

        /// <summary>
        ///     Gets the context.
        /// </summary>
        DbContext Context { get; }

         

      
    }
}