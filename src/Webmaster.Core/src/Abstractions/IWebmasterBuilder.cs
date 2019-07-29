using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public interface IWebmasterBuilder
    {
        IServiceCollection Services { get; }
    }
}
