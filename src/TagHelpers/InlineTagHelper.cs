using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Wangkanai.Webmaster.TagHelpers
{
    public abstract class InlineTagHelper : TagHelper
    {
        protected const  string              HrefAttributeName = "href";
        protected const  string              SrcAttributeName  = "src";
        private const    string              CacheKeyPrefix    = "InlineTagHelper-";
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMemoryCache        _cache;

        [ActivatorUtilitiesConstructor]
        public InlineTagHelper( IUrlHelperFactory urlHelperFactory)
        {
            
        }
        [Obsolete]
        protected InlineTagHelper(IWebHostEnvironment hostingEnvironment, IMemoryCache cache)
        {
            _hostingEnvironment = hostingEnvironment;
            _cache              = cache;
        }

        private async Task<T> GetContentAsync<T>(ICacheEntry entry, string path, Func<IFileInfo, Task<T>> getContent)
        {
            var fileProvider = _hostingEnvironment.WebRootFileProvider;
            var changeToken  = fileProvider.Watch(path);

            entry.SetPriority(CacheItemPriority.NeverRemove);
            entry.AddExpirationToken(changeToken);

            var file = fileProvider.GetFileInfo(path);
            if (file == null || !file.Exists)
                return default;

            return await getContent(file);
        }

        protected Task<string> GetFileContentAsync(string path)
            => _cache.GetOrCreateAsync(
                CacheKeyPrefix + path,
                entry => GetContentAsync(entry, path, ReadFileContentAsStringAsync));

        protected Task<string> GetFileContentBase64Async(string path)
            => _cache.GetOrCreateAsync(
                CacheKeyPrefix + path,
                entry => GetContentAsync(entry, path, ReadFileContentAsBase64Async));

        private static async Task<string> ReadFileContentAsStringAsync(IFileInfo file)
        {
            await using var stream = file.CreateReadStream();

            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }

        private static async Task<string> ReadFileContentAsBase64Async(IFileInfo file)
        {
            await using var stream = file.CreateReadStream();

            await using var writer = new MemoryStream();
            await stream.CopyToAsync(writer);
            writer.Seek(0, SeekOrigin.Begin);

            return Convert.ToBase64String(writer.ToArray());
        }
    }
}