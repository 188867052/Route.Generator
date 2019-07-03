namespace Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.Encodings.Web;
    using Api.Properties;
    using DependencyInjection.Analyzer;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using Microsoft.AspNetCore.Routing;
    using Newtonsoft.Json;
    using Route.Generator;

    public class RouteController : Controller
    {
        private readonly IRouteAnalyzer routeAnalyzer;

        public RouteController(IRouteAnalyzer routeAnalyzer)
        {
            this.routeAnalyzer = routeAnalyzer;
        }

        [HttpGet]
        [Route(Router.DefaultRoute)]
        public IActionResult ShowAllRoutes()
        {
            var value = this.routeAnalyzer.GetAllRouteInfo();
            return this.HightJson2Html(value.ToList());
        }

        private IActionResult HightJson(object value)
        {
            var json = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            string content = Resources.HtmlFormat.Replace("{{json}}", json);
            return this.Content(content, "text/html", Encoding.UTF8);
        }

        private IActionResult HightJson2Html(IList<RouteInfo> routeInfos)
        {
            var head = HtmlContent.TagHelper("tr");
            head.Content.AppendHtml(HtmlContent.TagHelper("th", "Index"));
            head.Content.AppendHtml(HtmlContent.TagHelper("th", nameof(RouteInfo.HttpMethods)));
            head.Content.AppendHtml(HtmlContent.TagHelper("th", nameof(RouteInfo.Path)));
            head.Content.AppendHtml(HtmlContent.TagHelper("th", nameof(RouteInfo.Area)));
            head.Content.AppendHtml(HtmlContent.TagHelper("th", nameof(RouteInfo.ControllerName)));
            head.Content.AppendHtml(HtmlContent.TagHelper("th", nameof(RouteInfo.ActionName)));
            head.Content.AppendHtml(HtmlContent.TagHelper("th", nameof(RouteInfo.Parameters)));
            head.Content.AppendHtml(HtmlContent.TagHelper("th", nameof(RouteInfo.Namespace)));

            var thead = HtmlContent.TagHelper("thead", head);

            var tbody = HtmlContent.TagHelper("tbody");
            foreach (var item in routeInfos)
            {
                var tr = HtmlContent.TagHelper("tr");
                tr.Content.AppendHtml(HtmlContent.TagHelper("td", (routeInfos.IndexOf(item) + 1).ToString()));
                tr.Content.AppendHtml(HtmlContent.TagHelper("td", item.HttpMethods));
                tr.Content.AppendHtml(HtmlContent.TagHelper("td", item.Path));
                tr.Content.AppendHtml(HtmlContent.TagHelper("td", item.Area));
                tr.Content.AppendHtml(HtmlContent.TagHelper("td", item.ControllerName));
                tr.Content.AppendHtml(HtmlContent.TagHelper("td", item.ActionName));
                string parameters = string.Empty;
                foreach (var parameter in item.Parameters)
                {
                    parameters += $"{parameter.Name}({parameter.Type})" + Environment.NewLine;
                }

                tr.Content.AppendHtml(HtmlContent.TagHelper("td", parameters));
                tr.Content.AppendHtml(HtmlContent.TagHelper("td", item.Namespace));
                tbody.Content.AppendHtml(tr);
            }

            var table = HtmlContent.TagHelper("table", new TagHelperAttributeList
            {
                { "class", "table table-bordered table-striped with-check" },
            }, thead, tbody);
            using (var writer = new StringWriter())
            {
                table.WriteTo(writer, HtmlEncoder.Default);
                string content = Resources.TableFormat.Replace("{{table}}", writer.ToString());
                content = content.Replace("{{title}}", "routes");
                return this.Content(content, "text/html", Encoding.UTF8);
            }
        }
    }
}
