using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Web;

namespace Route.Generator
{
    public partial class RouteController : Controller
    {
        [HttpGet]
        [Route(RouteAnalyzerExtensions.DefaultRouteClass)]
        public IActionResult ShowClass()
        {
            var text = GeneratorClass.GenerateCodeAsync("http://localhost:27634/").Result;
            string html2 = this.Html(HttpUtility.HtmlEncode(text), "cs");
            return this.Content(html2, "text/html", Encoding.UTF8);
        }

        private string Html(string xml, string type)
        {
            var css = "/*\n\nVisual Studio-like style based on original C# coloring by Jason Diamond <jason@diamond.name>\n\n*/\n.hljs {\n  display: block;\n  overflow-x: auto;\n  padding: 0.5em;\n  background: white;\n  color: black;\n}\n\n.hljs-comment,\n.hljs-quote,\n.hljs-variable {\n  color: #008000;\n}\n\n.hljs-keyword,\n.hljs-selector-tag,\n.hljs-built_in,\n.hljs-name,\n.hljs-tag {\n  color: #00f;\n}\n\n.hljs-string,\n.hljs-title,\n.hljs-section,\n.hljs-attribute,\n.hljs-literal,\n.hljs-template-tag,\n.hljs-template-variable,\n.hljs-type,\n.hljs-addition {\n  color: #a31515;\n}\n\n.hljs-deletion,\n.hljs-selector-attr,\n.hljs-selector-pseudo,\n.hljs-meta {\n  color: #2b91af;\n}\n\n.hljs-doctag {\n  color: #808080;\n}\n\n.hljs-attr {\n  color: #f00;\n}\n\n.hljs-symbol,\n.hljs-bullet,\n.hljs-link {\n  color: #00b0e8;\n}\n\n\n.hljs-emphasis {\n  font-style: italic;\n}\n\n.hljs-strong {\n  font-weight: bold;\n}\n";
            var script1 = HtmlContent.TagHelper("script", new TagHelperAttribute("src", "/highlight.js"));
            var script4 = HtmlContent.TagHelper("script", "hljs.initHighlightingOnLoad();");
            var cssTag = HtmlContent.TagHelper("style", css);
            var head = HtmlContent.TagHelper("head", cssTag, script1, script4);
            var code = HtmlContent.TagHelper("code", new TagHelperAttribute("class", type), xml);
            var pre = HtmlContent.TagHelper("pre", code);
            var body = HtmlContent.TagHelper("body", pre);
            var html = HtmlContent.TagHelper("html", head, body);
            return HtmlContent.ToHtml(html);
        }
    }
}
