﻿using Microsoft.AspNetCore.Routing.Constraints;
using System.Text.RegularExpressions;

namespace Wangkanai.Webmaster.Routing
{
    public class EnglishLanguageRouteContraint : RegexRouteConstraint
    {
        public EnglishLanguageRouteContraint() : base(new Regex("^[a-zA-Z]*$")) { }
    }

    public class ThaiLanguageRouteContraint : RegexRouteConstraint
    {
        public ThaiLanguageRouteContraint() : base(new Regex(@"^\p{IsThai}*$")) { }
    }

    public class LaoLanguageRouteContraint : RegexRouteConstraint
    {
        public LaoLanguageRouteContraint() : base(new Regex(@"^\p{IsLao}*$")) { }
    }

    public class MyanmarLanguageRouteContraint : RegexRouteConstraint
    {
        public MyanmarLanguageRouteContraint() : base(new Regex("^[U+1000–U+109F]*$")) { }
    }
}
