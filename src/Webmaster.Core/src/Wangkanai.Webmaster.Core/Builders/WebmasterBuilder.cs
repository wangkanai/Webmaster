using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Wangkanai.Webmaster.Builders
{
    public class WebmasterBuilder : IWebmasterBuilder
    {
        public WebmasterBuilder(IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            Services = services;
        }

        public IServiceCollection Services { get; private set; }
    }
}
