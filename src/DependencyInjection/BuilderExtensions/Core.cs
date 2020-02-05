// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Wangkanai.Webmaster.Builders;
using Wangkanai.Webmaster.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CoreCollectionExtensions
    {
        public static IWebmasterBuilder AddCoreServices(this IWebmasterBuilder builder)
        {
            builder.Services.AddDetection();

            return builder;
        }

        public static IWebmasterBuilder AddMarkerService(this IWebmasterBuilder builder)
        {
            builder.Services.TryAddSingleton<MarkerService, MarkerService>();

            return builder;
        }
    }
}