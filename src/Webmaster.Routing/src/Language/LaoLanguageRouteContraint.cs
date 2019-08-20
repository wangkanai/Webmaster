using Microsoft.AspNetCore.Routing.Constraints;

namespace Wangkanai.Webmaster.Routing.Language
{
    public class LaoLanguageRouteContraint: RegexRouteConstraint
    {
        public LaoLanguageRouteContraint() : base("[\u0E80—\u0EFF]") { }
    }
}
