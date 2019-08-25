using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wangkanai.Webmaster.TagHelpers
{
    [HtmlTargetElement(CanonicalAttributeName)]
    public class CanonicalTagHelper : TagHelper
    {
        private const string CanonicalAttributeName = "seo-canonical";        
        private const string HrefAttributeName = "href";
        private const string RelAttributeName = "rel";

        public CanonicalTagHelper() { }

        public override int Order => -1000;

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public string Site { get; set; }
        public string Path { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            output.TagName = "link";
            // output.Attributes.Clear();

            output.Attributes.Add(RelAttributeName, "canonical");

            if (string.IsNullOrEmpty(Path))
            {
                Path = ViewContext.HttpContext.Request.Path;
            }

            output.Attributes.Add(HrefAttributeName, Site + Path);
        }
    }

    public class MetaKeywordTagHelper : TagHelper { }

    public class MetaDescriptionTagHelper : TagHelper { }
}
