﻿using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Caching.Memory;

namespace Wangkanai.Webmaster.TagHelpers
{
    [HtmlTargetElement(InlineScriptAttributeName, Attributes = HrefAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    public class InlineScriptTagHelper : InlineTagHelper
    {
        private const string InlineScriptAttributeName = "inline-script";
        private const string HrefAttributeName         = "href";

        [HtmlAttributeName(HrefAttributeName)]
        public string Href { get; set; }

        public InlineScriptTagHelper(IWebHostEnvironment webHostEnvironment, IMemoryCache cache, HtmlEncoder htmlEncoder, IUrlHelperFactory urlHelperFactory)
            : base(webHostEnvironment, cache, htmlEncoder, urlHelperFactory)
        {
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));
            if (output is null)
                throw new ArgumentNullException(nameof(output));

            var fileContent = await GetFileContentStringAsync(Href);
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