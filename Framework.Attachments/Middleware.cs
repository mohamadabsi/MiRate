
using Framework.Attachments.Data;
using Framework.Core.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace Framework.Attachments
{
    public  static partial class AttachmentsExtensions
    {
         public static void UseAttachments(this IApplicationBuilder app, IHostEnvironment env, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            app.Migrate<AttachmentsDbContext>(serviceProvider, configuration, env);
        }
    }
}
