using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wangkanai.Webmaster.TagHelpers
{
    [HtmlTargetElement("img", Attributes = SrcAttributeName , TagStructure = TagStructure.WithoutEndTag)]
    public class ImageInlineTagHelper :TagHelper
    {
        private const string ImgAttributeName = "img";
        private const string SrcAttributeName = "inline-src";

        public ImageInlineTagHelper()     {        }

        public override int Order => -1000;

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (output == null)
                throw new ArgumentNullException(nameof(context));

            output.TagName = "img";

            output.Attributes.Add("src", "data:image/svg+xml;base64,");

            return base.ProcessAsync(context, output);
        }
    }
}
