using Microsoft.AspNetCore.Routing.Constraints;

namespace Wangkanai.Webmaster.Routing.Language
{
    public class MyanmarLanguageRouteContraint : RegexRouteConstraint
    {
        public MyanmarLanguageRouteContraint() : base("[\u1000—\u109F]") { }
    }
}
