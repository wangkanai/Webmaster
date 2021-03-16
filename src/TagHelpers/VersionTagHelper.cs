﻿using System;
using System.Reflection;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Wangkanai.Webmaster.TagHelpers
{
    [HtmlTargetElement(ElementName, Attributes = FieldCountAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    public class VersionTagHelper : TagHelper
    {
        private const string ElementName = "version";
        private const string FieldCountAttributeName = "field";

        [HtmlAttributeName(FieldCountAttributeName)]
        public int FieldCount { get; set; } = 3;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));
            if (output is null)
                throw new ArgumentNullException(nameof(output));
            
            var version = Assembly.GetEntryAssembly()?.GetName().Version;
            if (version is null)
            {
                output.SuppressOutput();
                return;
            }
            
            output.TagName = "span";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.Append(version.ToString(FieldCount));
        }
    }
}