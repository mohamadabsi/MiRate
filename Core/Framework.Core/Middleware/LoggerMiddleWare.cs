using Framework.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Framework.Core.Middleware
{
    public class LoggerMiddleware
    {
        RequestDelegate _next;
        ILogger logger;
        private readonly IApplicationBuilder app;

        public LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> logger, IApplicationBuilder app)
        {
            _next = next;
            this.logger = logger;
            this.app = app;
        }
        public async Task Invoke(HttpContext context)
        {
            Trace.CorrelationManager.ActivityId = Guid.NewGuid();
            var xml = context.Request?.Headers["X-Requested-With"];
            Stream originBody = ReplaceBody(context.Response);

            try
            {
                await _next(context);

                var isHtml = context.Response.ContentType?.ToLower().Contains("text/html");
                if (!isHtml.HasValue)
                {
                    ReturnBody(context.Response, originBody);
                    return;
                }
                if (!isHtml.Value)
                {
                    ReturnBody(context.Response, originBody);
                    return;
                }
                if (!context.Request.Path.HasValue || context.Request.Path.Value.ToLower().Contains("changepassword"))
                {
                    ReturnBody(context.Response, originBody);
                    return;
                }


                ReturnBody(context.Response, originBody);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, null);

                context.Response.Redirect("Error");

                ReturnBody(context.Response, originBody);
            }
        }

        private Stream ReplaceBody(HttpResponse response)
        {
            var originBody = response.Body;
            response.Body = new MemoryStream();
            return originBody;
        }

        private void ReturnBody(HttpResponse response, Stream originBody)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            response.Body.CopyTo(originBody);
            response.Body = originBody;
        }
    }
}
