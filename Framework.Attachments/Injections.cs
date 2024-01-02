
using Framework.Core.Data;
using Framework.Core.Data.Repositories;
using Framework.Core.Data.Uow;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Framework.Attachments.Data;
using Framework.Core.DependencyManagement;
using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.Hosting;

namespace Framework.Attachments
{
    public static partial class AttachmentsExtensions
    {


        public static void AddAttachments(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
      
            services.UseDatabase<AttachmentsDbContext>(configuration, environment, "AttachmentsConnection");

            services.AddScoped(typeof(IUnitOfWorkBase<>), typeof(UnitOfWorkBase<>));

            services.AddScoped<IAttachmentsUnitOfWork, AttachmentsUnitOfWork>();

            services.AddScoped(typeof(IEfCoreRepository<,>), typeof(EfCoreRepository<,>));

            services.AddScoped(typeof(IAttachmentsDbContext), typeof(AttachmentsDbContext));

            services.AddScoped(typeof(IAttachmentsRepository<>), typeof(AttachmentsRepository<>));

          

         
        }
      
    }
}
