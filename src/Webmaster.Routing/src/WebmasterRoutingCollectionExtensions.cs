using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Wangkanai.Webmaster.Routing;
using Wangkanai.Webmaster.Routing.Language;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WebmasterRoutingCollectionExtensions
    {
        public static IWebmasterBuilder AddRoutingContraint(this IWebmasterBuilder builder)
        {
            if (builder == null) throw new AddRoutingArgumentNullException(nameof(builder));

            builder.Services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("thai", typeof(ThaiLanguageRouteContraint));                
                options.ConstraintMap.Add("lao", typeof(LaoLanguageRouteContraint));
                options.ConstraintMap.Add("myanmar", typeof(MyanmarLanguageRouteContraint));
            });

            return builder;
        }
    }
}
