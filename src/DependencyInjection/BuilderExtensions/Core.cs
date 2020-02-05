// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using System;
using Wangkanai.Webmaster.Builders;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CoreCollectionExtensions
    {
        public static IWebmasterBuilder AddCoreServices(this IWebmasterBuilder builder)
        {
            builder.Services.AddDetection();

            return builder;
        }
    }
}