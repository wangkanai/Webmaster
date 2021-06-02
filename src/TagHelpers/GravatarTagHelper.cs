// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Wangkanai.Cryptography;
using Wangkanai.Webmaster.Models;

namespace Wangkanai.Webmaster.TagHelpers
{
    [HtmlTargetElement(GravatarAttributeName, Attributes = EmailAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement(GravatarAttributeName, Attributes = SizeAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement(GravatarAttributeName, Attributes = RatingAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement(GravatarAttributeName, Attributes = ModeAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    public class GravatarTagHelper : TagHelper
    {
        private const string GravatarAttributeName = "gravatar";
        private const string EmailAttributeName = "email";
        private const string SizeAttributeName = "size";
        private const string RatingAttributeName = "rating";
        private const string ModeAttributeName = "mode";

        public override int Order => -1000;

        [HtmlAttributeName(EmailAttributeName)]
        [EmailAddress]
        public string Email { get; set; }

        [HtmlAttributeName(SizeAttributeName)]
        public IconSize Size { get; set; }

        [HtmlAttributeName(RatingAttributeName)]
        public Rating Rating { get; set; } = Rating.g;

        [HtmlAttributeName(ModeAttributeName)]
        public Mode Mode { get; set; } = Mode.Default;

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            Check.NotNull(context, nameof(context));
            Check.NotNull(output, nameof(output));
            
            output.TagName = "img";
            var hash  = Email.HashMd5();
            var uri   = $"https://www.gravatar.com/avatar/{hash}";
            var query = new QueryBuilder();
            if (Size > 0)
                query.Add("s", Size.ToInt().ToString());
            if (Rating != Rating.g)
                query.Add("r", Rating.ToString());
            if (Mode != Mode.Default)
                query.Add("d", GetMode(Mode));
            uri = uri + Uri.EscapeUriString(query.ToQueryString().ToString());
            var src = new TagHelperAttribute("src", uri);
            output.Attributes.Add(src);

            return base.ProcessAsync(context, output);
        }

        private string GetMode(Mode mode)
        {
            if (mode == Mode.NotFound)
                return "404";
            return mode.ToString().ToLower();
        }
    }

    public enum Rating
    {
        g,
        pg,
        r,
        x
    }

    public enum Mode
    {
        [Display(Name = "404")]
        NotFound,

        [Display(Name = "Mp")]
        Mp,

        [Display(Name = "Identicon")]
        Identicon,

        [Display(Name = "Monsterid")]
        Monsterid,

        [Display(Name = "Wavatar")]
        Wavatar,

        [Display(Name = "Retro")]
        Retro,

        [Display(Name = "Blank")]
        Blank,

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        Default
    }
}