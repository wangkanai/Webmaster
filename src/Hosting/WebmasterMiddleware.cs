using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Wangkanai.Webmaster
{
    //[Experimental()]
    //[Deprecated()]
    //[Obsolete()]
    public class WebmasterMiddleware
    {
        private readonly RequestDelegate _next;

        public WebmasterMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            await _next(context).ConfigureAwait(false);
        }
    }
}