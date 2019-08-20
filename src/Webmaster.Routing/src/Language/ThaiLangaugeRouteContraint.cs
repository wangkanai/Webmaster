using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Wangkanai.Webmaster.Routing.Language
{
    public class ThaiLanguageRouteContraint : RegexRouteConstraint
    {
        public ThaiLanguageRouteContraint() : base("[\u0E00-\u0E7F]") { }
    }

    public class LanguageRouteContraint : RegexRouteConstraint
    {
        public LanguageRouteContraint() : base("[a-z]") { }
    }
}
