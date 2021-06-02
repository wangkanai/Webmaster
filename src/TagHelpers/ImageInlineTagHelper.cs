// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Hosting;

using System;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using Microsoft.Extensions.FileProviders;

using Wangkanai.Webmaster.Razor.TagHelpers;

namespace Wangkanai.Webmaster.TagHelpers
{
    [HtmlTargetElement(ImgAttributeName, Attributes = InlineAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    public class ImageInlineTagHelper : UrlResolutionTagHelper
    {
        private const string ImgAttributeName    = "img";
        private const string InlineAttributeName = "inline";
        private const string SrcAttributeName    = "src";

        public override int Order => -1000;

        [HtmlAttributeName(InlineAttributeName)]
        public string Inline { get; set; }

        internal IFileVersionProvider FileVersionProvider { get; private set; }

        public ImageInlineTagHelper(
            HtmlEncoder       htmlEncoder,
            IUrlHelperFactory urlHelperFactory)
            : base(urlHelperFactory, htmlEncoder)
        {
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            Check.NotNull(context, nameof(context));
            Check.NotNull(output, nameof(output));

            output.CopyHtmlAttribute(SrcAttributeName, context);

            return base.ProcessAsync(context, output);
        }

        private string ImageInline(string contentType, string base64)
        {
            return $"data:{contentType};base64,{base64}";
        }

        private string GetFileContentType(string path)
        {
            if (path.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                return "image/jpeg";
            if (path.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                return "image/gif";
            if (path.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                return "image/png";
            if (path.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                return "image/svg+xml";
            throw new ArgumentException("Unknown file type");
        }

        private string GetFileContentType(FileInfo info)
            => info.Extension switch
               {
                   "jpg" => "image/jpeg",
                   "gif" => "image/gif",
                   "png" => "image/png",
                   "svg" => "image/svg+xml",
                   _ => throw new ArgumentNullException("Unknown file type"),
               };


        private string ConvertToBase64(byte[] array)
            => Convert.ToBase64String(array);

        private HtmlString InlineImage(IHtmlHelper html, string path, object attributes = null)
        {
            Check.NotNull(html, nameof(html));
            
            var env         = html.ViewContext.HttpContext.RequestServices.GetService(typeof(IHostEnvironment)) as IHostEnvironment;
            var fileinfo    = env.ContentRootFileProvider.GetFileInfo(path);
            var contentType = GetFileContentType(path);

            using var stream = fileinfo.CreateReadStream();

            var array = new byte[stream.Length];
            stream.Read(array, 0, array.Length);
            var base64 = ConvertToBase64(array);

            var props = attributes?.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(attributes));
            var attrs = props == null
                            ? string.Empty
                            : string.Join(" ", props.Select(x => $"{x.Key}=\"{x.Value}\""));

            var img = $"<img src=\"data:{contentType};base64,{base64}\" {attrs}";

            return new HtmlString(img);
        }
    }
}