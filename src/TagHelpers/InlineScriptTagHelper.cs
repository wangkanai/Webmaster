using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Caching.Memory;

namespace Wangkanai.Webmaster.TagHelpers
{
    [HtmlTargetElement(InlineScriptAttributeName, Attributes = HrefAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    public class InlineScriptTagHelper : InlineTagHelper
    {
        private const string InlineScriptAttributeName = "inline-script";

        [HtmlAttributeName(HrefAttributeName)]
        public string Href { get; set; }

        public InlineScriptTagHelper(IWebHostEnvironment webHostEnvironment, IMemoryCache cache)
            : base(webHostEnvironment, cache)
        {
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));
            if (output is null)
                throw new ArgumentNullException(nameof(output));

            var fileContent = await GetFileContentAsync(Href);
            if (fileContent is null)
            {
                output.SuppressOutput();
                return;
            }

            output.TagName = "script";
            output.Attributes.RemoveAll("href");
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.AppendHtml(fileContent);
        }
    }
}