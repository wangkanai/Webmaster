﻿using System;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

using Wangkanai.Extensions;

namespace Wangkanai.Webmaster.TagHelpers
{
    [HtmlTargetElement(
        "img",
        Attributes   = InlineAttributeName + "," + SrcAttributeName,
        TagStructure = TagStructure.WithoutEndTag)]
    public class ImageInlineTagHelper : ImageTagHelper
    {
        private const string InlineAttributeName = "inline";
        private const string SrcAttributeName    = "src";

        //private const string AppendVersionAttributeName = "asp-append-version";

        [ActivatorUtilitiesConstructor]
        public ImageInlineTagHelper(IWebHostEnvironment webHostEnvironment, IFileVersionProvider fileVersionProvider, HtmlEncoder htmlEncoder, IUrlHelperFactory urlHelperFactory)
            : base(fileVersionProvider, htmlEncoder, urlHelperFactory)
        {
            FileProvider = webHostEnvironment.WebRootFileProvider;
        }

        public override int Order => -999;

        [HtmlAttributeName(SrcAttributeName)]
        public string Src { get; set; }

        [HtmlAttributeName(InlineAttributeName)]
        public bool Inline { get; set; }

        private IFileProvider FileProvider { get; set; }
        private IFileInfo     FileInfo     { get; set; }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            Check.NotNull(context, nameof(context));
            Check.NotNull(output, nameof(output));

            output.CopyHtmlAttribute(SrcAttributeName, context);
            ProcessUrlAttribute(SrcAttributeName, output);
            var path    = output.Attributes[SrcAttributeName].Value as string;
            var payload = await Payload(path);
            output.Attributes.SetAttribute(SrcAttributeName, payload);
        }

        private async Task<string> Payload(string path)
        {
            FileInfo = FileProvider.GetFileInfo(path);
            var data    = FileInfo.ContentType();
            var content = await GetContentBase64Async();
            return $"data:{data};base64,{content}";
        }

        private async Task<string> GetContentBase64Async()
        {
            await using var stream = FileInfo.CreateReadStream();
            await using var writer = new MemoryStream();
            await stream.CopyToAsync(writer);
            writer.Seek(0, SeekOrigin.Begin);
            return Convert.ToBase64String(writer.ToArray());
        }
    }
}