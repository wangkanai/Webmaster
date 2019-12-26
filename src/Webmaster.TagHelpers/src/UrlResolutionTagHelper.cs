// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Text.Encodings.Web;

namespace Wangkanai.Webmaster.Razor.TagHelpers
{
    [HtmlTargetElement("img", Attributes = "[inline^='~/']", TagStructure = TagStructure.WithoutEndTag)]
    public class UrlResolutionTagHelper : TagHelper
    {
        public UrlResolutionTagHelper(IUrlHelperFactory urlHelperFactory, HtmlEncoder htmlEncoder)
        {
            UrlHelperFactory = urlHelperFactory;
            HtmlEncoder = htmlEncoder;
        }

        public override int Order => -1000 - 999;
        protected IUrlHelperFactory UrlHelperFactory { get; }
        protected HtmlEncoder HtmlEncoder { get; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext? ViewContent { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (output == null)
                throw new ArgumentNullException(nameof(output));
            if (output.TagName == null)
                return;
        }
    }
}