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
    }

    public class MetaKeywordTagHelper : TagHelper { }

    public class MetaDescriptionTagHelper : TagHelper { }
}
