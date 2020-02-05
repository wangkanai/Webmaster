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
            if (app is null)
                throw new ArgumentNullException(nameof(app));

            app.Validate();
            
            app.UseDetection();

            return app.UseMiddleware<WebmasterMiddleware>();
        }

        private static void Validate(this IApplicationBuilder app)
        {
            // What should I validate?
        }
    }
}