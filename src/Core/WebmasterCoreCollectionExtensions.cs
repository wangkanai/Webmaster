// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using System;
using Wangkanai.Webmaster.Builders;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WebmasterCoreCollectionExtensions
    {
        public static IWebmasterCoreBuilder AddWebmasterCore(this IServiceCollection services)
        {
            if (services == null)
                throw new AddWebmasterCoreArgumentNullException(nameof(services));

            services.AddDetection();

            return new WebmasterCoreBuilder(services);
        }
    }
}