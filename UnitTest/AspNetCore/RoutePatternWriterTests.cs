﻿namespace UnitTest
{
    using System.Text;
    using Microsoft.AspNetCore.Routing.Patterns;
    using Xunit;

    public class RoutePatternWriterTests
    {
        [Theory]
        [InlineData(@"")]
        [InlineData(@"Literal")]
        [InlineData(@"Literal1/Literal2")]
        [InlineData(@"{controller}")]
        [InlineData(@"{controller}/{action}")]
        [InlineData(@"{controller}/{action}/{param:test(\?)?}")]
        [InlineData(@"{param:test(\w,\w)=jsd}")]
        [InlineData(@"some/url-{p1:int:test(3)=hello}/{p2=abc}/{p3?}")]
        [InlineData(@"{param:test(abc:somevalue):name(test1:differentname=default-value}")]
        [InlineData(@"api/Blog/{controller}/{action}/{id?}")]
        [InlineData(@"{p1}.{p2}.{p3}")]
        public void ToString_TemplateRoundtrips(string template)
        {
            var routePattern = RoutePatternFactory.Parse(template);

            var sb = new StringBuilder();
            RoutePatternWriter.WriteString(sb, routePattern.PathSegments);

            Assert.Equal(template, sb.ToString());
        }
    }
}
