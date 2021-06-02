using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Caching.Memory;

namespace Wangkanai.Webmaster.TagHelpers
{
    [HtmlTargetElement(InlineImgAttributeName, Attributes = SrcAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    public class InlineImgTagHelper : InlineTagHelper
    {
        private static readonly FileExtensionContentTypeProvider _provider = new FileExtensionContentTypeProvider();

        private const string InlineImgAttributeName = "inline-img";

        [HtmlAttributeName(SrcAttributeName)]
        public string Src { get; set; }

        public InlineImgTagHelper(IWebHostEnvironment webHostEnvironment, IMemoryCache cache)
            : base(webHostEnvironment, cache)
        {
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var fileContent = await GetFileContentBase64Async(Src);
            if (fileContent is null)
            {
                output.SuppressOutput();
                return;
            }

            if (!_provider.TryGetContentType(Src, out var contentType))
                contentType = "application/octet-stream";

            var srcAttributeValue = $"data:{contentType};base64,{fileContent}";

            output.TagName = "img";
            output.Attributes.RemoveAll("src");
            output.Attributes.Add(SrcAttributeName, srcAttributeValue);
            output.TagMode = TagMode.SelfClosing;
            output.Content.AppendHtml(fileContent);
        }
    }
}