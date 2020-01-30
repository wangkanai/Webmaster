using Microsoft.AspNetCore.Builder;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Wangkanai.Webmaster.Core.Builders
{
    /// <summary>
    /// Extension method for adding the <see cref="WebmasterMiddleware"/> to the application.
    /// </summary>
    public static class WebmasterApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseWebmaster(this IApplicationBuilder app)
        {
            if (app == null)
                throw new UseWebmasterArgumentNullException(nameof(app));

            app.UseDetection();

            return app.UseMiddleware<WebmasterMiddleware>();
        }
    }
}