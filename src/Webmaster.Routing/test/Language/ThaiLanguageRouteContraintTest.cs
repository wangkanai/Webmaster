using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Wangkanai.Webmaster.Routing.Language;
using Xunit;

namespace Wangkanai.Webmaster.Routing.Tests.Language
{
    public class ThaiLanguageRouteContraintTest
    {
        [Theory]
        [InlineData("กรุงเทพ", true)]
        [InlineData("Bangkok", false)]
        [InlineData("กรุงเทพ1", true)]      // want it to be false
        [InlineData("กรุงเทพabc", true)]    // want it to be false
        [InlineData("Bangkokกทม", true)]  // want it to be false
        public void ThaiRegexContraintFromInput(string routeValue, bool shouldMatch)
        {
            // arrage
            var contraint = new ThaiLanguageRouteContraint();
            var values = new RouteValueDictionary(new { controller = routeValue });

            // act
            bool match = Match(contraint, values);

            // assert
            Assert.Equal(shouldMatch, match);
        }

        private bool Match(ThaiLanguageRouteContraint contraint, RouteValueDictionary values)
        {
            return contraint.Match(
                new DefaultHttpContext(),
                route: new Mock<IRouter>().Object,
                routeKey: "controller",
                values: values,
                routeDirection: RouteDirection.IncomingRequest);
        }
    }
}
