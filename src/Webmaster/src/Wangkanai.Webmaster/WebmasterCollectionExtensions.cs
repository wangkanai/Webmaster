using System;
using System.Collections.Generic;
using System.Text;
using Wangkanai.Webmaster.Builders;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WebmasterCollectionExtensions
    {
        public static IWebmasterBuilder AddWebmaster(this IServiceCollection services)
        {
            if (services == null)
                throw new AddWebmasterArgumentNullException(nameof(services));

            services.AddWebmasterCore();

            return new WebmasterBuilder(services);
        }
    }
}
