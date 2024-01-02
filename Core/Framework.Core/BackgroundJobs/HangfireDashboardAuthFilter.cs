﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HangfireDashboardAuthFilter.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.BackgroundJobs
{
    #region usings

    using Hangfire.Dashboard;

    #endregion

    /// <summary>
    /// The hangfire dashboard auth filter.
    /// </summary>
    public class HangfireDashboardAuthFilter : IDashboardAuthorizationFilter
    {
        public HangfireDashboardAuthFilter()
        {

        }
        /// <summary>
        /// The authorize.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Authorize(DashboardContext context  )
        {
            var httpContext = context.GetHttpContext();

            return httpContext.User.Identity.IsAuthenticated;
             // && httpContext.User.IsInRole("SystemAdmin");

        }
    }
}