using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using Wangkanai.Responsive;

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

            app.UseResponsive();

            return app.UseMiddleware<WebmasterMiddleware>();
        }
    }
}
