using System;
using System.Collections.Generic;
using System.Text;
using Wangkanai.Webmaster.Builders;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WebmasterCoreCollectionExtensions
    {
        public static IWebmasterCoreBuilder AddWebmasterCore(this IServiceCollection services)
        {
            if (services == null)
                throw new AddWebmasterCoreArgumentNullException(nameof(services));

            return new WebmasterCoreBuilder(services);
        }
    }
}
