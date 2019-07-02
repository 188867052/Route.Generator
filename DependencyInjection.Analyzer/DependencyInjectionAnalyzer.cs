using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

namespace DependencyInjection.Analyzer
{
    public class DependencyInjectionAnalyzer : IDependencyInjectionAnalyzer
    {
        public const string DefaultRoute = "/services";

        public IEnumerable<DependencyInjectionInfo> GetDependencyInjectionInfo()
        {
            return DependencyInjectionAnalyzerExtention.ServiceCollection;
        }

        public static string GetHtml(IList<DependencyInjectionInfo> routeInfos)
        {
            var head = HtmlContent.TagHelper("tr");
            head.Content.AppendHtml(HtmlContent.TagHelper("th", nameof(DependencyInjectionInfo.Index)));
            head.Content.AppendHtml(HtmlContent.TagHelper("th", nameof(DependencyInjectionInfo.Lifetime)));
            head.Content.AppendHtml(HtmlContent.TagHelper("th", nameof(DependencyInjectionInfo.ImplementationType)));
            head.Content.AppendHtml(HtmlContent.TagHelper("th", nameof(DependencyInjectionInfo.ServiceType)));

            var thead = HtmlContent.TagHelper("thead", head);

            var tbody = HtmlContent.TagHelper("tbody");
            foreach (var item in routeInfos)
            {
                var tr = HtmlContent.TagHelper("tr");
                tr.Content.AppendHtml(HtmlContent.TagHelper("td", item.Index.ToString()));
                tr.Content.AppendHtml(HtmlContent.TagHelper("td", item.Lifetime));
                tr.Content.AppendHtml(HtmlContent.TagHelper("td", item.ImplementationType));
                tr.Content.AppendHtml(HtmlContent.TagHelper("td", item.ServiceType));
                tbody.Content.AppendHtml(tr);
            }

            var table = HtmlContent.TagHelper("table", new TagHelperAttributeList
            {
                { "class", "table table-bordered table-striped with-check" },
            }, thead, tbody);
            using (var writer = new StringWriter())
            {

                TagHelperAttributeList attributes = new TagHelperAttributeList
                {
                        { "href", "https://cdn.staticfile.org/twitter-bootstrap/3.0.3/css/bootstrap.min.css" },
                        {"rel","stylesheet" }
                };

                var title = HtmlContent.TagHelper("title", "services");
                var link = HtmlContent.TagHelper("link", attributes);
                var htmlHead = HtmlContent.TagHelper("head", title, link);
                var htmlBody = HtmlContent.TagHelper("body", table);
                htmlHead.PostElement.SetHtmlContent(htmlBody);
                htmlHead.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }
    }
}
