using System;
using Microsoft.Extensions.DependencyInjection;

namespace Wangkanai.Webmaster.Builders
{
    public class WebmasterCoreBuilder : IWebmasterCoreBuilder
    {
        public WebmasterCoreBuilder(IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            Services = services;
        }

        public IServiceCollection Services { get; private set; }
    }
}
