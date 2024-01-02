using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Authentication;
namespace Framework.Core.Middleware

{
    public static class AuthorizationMiddleWare
    {

        public static void AddAuthorizationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            // var list = typeof(AppRoles).GetEnumAppRoleDesc();
            // var areas = list.SelectMany(l => l.AllowedAreas).Distinct();

            // services.AddMvc().AddRazorPagesOptions(options =>
            // {
            //     foreach (var item in areas)
            //     {
            //         options.Conventions.AuthorizeAreaFolder(item, "/", $"Only{item}Access");
            //     }
            //     options.Conventions.AuthorizePage("/Index");
            //     options.Conventions.AuthorizePage("/filesc");
            //     options.Conventions.AuthorizePage("/EditUser");
            //     options.Conventions.AllowAnonymousToAreaPage("DAO", "/Details");
            //     options.Conventions.AllowAnonymousToAreaPage("PublicDelegates", "/Details");
            //     options.Conventions.AllowAnonymousToAreaPage("MediaDelegates", "/Details");
            //     options.Conventions.AllowAnonymousToAreaPage("DAORequests", "/Details");
            //     options.Conventions.AllowAnonymousToAreaPage("Evisa", "/EvisaSmartForm");
            //     options.Conventions.AllowAnonymousToAreaPage("Flights", "/Flights");
            //     options.Conventions.AllowAnonymousToAreaPage("Flights", "/ConfirmFlight");

            //     options.Conventions.AllowAnonymousToAreaPage("Accommodations", "/CompleteAccommodation");
            //     options.Conventions.AllowAnonymousToAreaPage("Accommodations", "/ConfirmAccommodation");
            //     options.Conventions.AllowAnonymousToAreaPage("Delegate", "/Accomodation");
            //     options.Conventions.AllowAnonymousToAreaPage("Workforce", "/Details");

            // });
            // services.AddAuthorization(options =>
            // {
            //     foreach (var area in areas)
            //     {
            //         var roles = list.Where(l => l.AllowedAreas.Contains(area)).Select(d => d.RoleName).Distinct().ToArray();
            //         options.AddPolicy($"Only{area}Access", policy => policy.RequireRole(roles));
            //     }

            // });
        }
    }
}
