// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Routing;
using Wangkanai.Webmaster.Routing;

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