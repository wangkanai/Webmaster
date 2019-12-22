using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Wangkanai.Webmaster
{
    public class WebmasterMiddleware
    {
        private readonly RequestDelegate _next;

        public WebmasterMiddleware(RequestDelegate next)
        {
            if (next == null)
                throw new WebmasterMiddlewareNextArgumentNullException(nameof(next));

            _next = next;
        }

        public async Task Invoke(HttpContext context) {
            if (context == null)
                throw new WebmasterMiddlewareInvokeContextArgumentNullException(nameof(context));

            await _next(context).ConfigureAwait(false);
        }
    }
}