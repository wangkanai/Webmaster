// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using Microsoft.Extensions.DependencyInjection;
using System;

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