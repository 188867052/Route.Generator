using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DependencyInjection.Analyzer
{
    public static class HtmlContent
    {
        public static string ToHtml(IHtmlContent content)
        {
            using (var writer = new StringWriter())
            {
                content.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }

        public static TagHelperOutput TagHelper(string tagName, TagHelperAttributeList attributes)
        {
            return new TagHelperOutput(tagName,
                                       attributes,
                                       getChildContentAsync: (useCachedResult, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));
        }

        public static TagHelperOutput TagHelper(string tagName, params IHtmlContent[] htmlContent)
        {
            var tagHelperOutput = new TagHelperOutput(tagName,
                                       new TagHelperAttributeList(),
                                       getChildContentAsync: (useCachedResult, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));

            return tagHelperOutput.AppendHtml(htmlContent);
        }

        public static TagHelperOutput TagHelper(string tagName)
        {
            return new TagHelperOutput(tagName,
                                       new TagHelperAttributeList(),
                                       getChildContentAsync: (useCachedResult, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));
        }

        public static TagHelperOutput TagHelper(string tagName, TagHelperAttributeList attributes, params string[] content)
        {
            TagHelperOutput tagHelperOutput = new TagHelperOutput(tagName,
                                                                  attributes,
                                                                  getChildContentAsync: (useCachedResult, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));
            return tagHelperOutput.AppendHtml(content);
        }

        public static TagHelperOutput TagHelper(string tagName, TagHelperAttribute attribute, string content)
        {
            TagHelperOutput tagHelperOutput = new TagHelperOutput(tagName,
                                                                  new TagHelperAttributeList { attribute },
                                                                  getChildContentAsync: (useCachedResult, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));
            return tagHelperOutput.AppendHtml(content);
        }

        public static TagHelperOutput TagHelper(string tagName, string content)
        {
            TagHelperOutput tagHelperOutput = new TagHelperOutput(tagName,
                                                                  new TagHelperAttributeList(),
                                                                  getChildContentAsync: (useCachedResult, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));
            return tagHelperOutput.AppendHtml(content);
        }

        public static TagHelperOutput TagHelper(string tagName, TagHelperAttributeList attributes, params IHtmlContent[] htmlContent)
        {
            TagHelperOutput tagHelperOutput = new TagHelperOutput(tagName,
                                                                  attributes,
                                                                  getChildContentAsync: (useCachedResult, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));
            return tagHelperOutput.AppendHtml(htmlContent);
        }

        public static TagHelperOutput TagHelper(string tagName, TagHelperAttribute attribute, params IHtmlContent[] htmlContent)
        {
            TagHelperOutput tagHelperOutput = new TagHelperOutput(tagName,
                                                                  new TagHelperAttributeList { attribute },
                                                                  getChildContentAsync: (useCachedResult, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));
            return tagHelperOutput.AppendHtml(htmlContent);
        }

        private static TagHelperOutput AppendHtml(this TagHelperOutput tagHelperOutput, params IHtmlContent[] htmlContent)
        {
            foreach (var item in htmlContent)
            {
                tagHelperOutput.Content.AppendHtml(item);
            }

            return tagHelperOutput;
        }

        private static TagHelperOutput AppendHtml(this TagHelperOutput tagHelperOutput, params string[] content)
        {
            foreach (var item in content)
            {
                tagHelperOutput.Content.AppendHtml(item);
            }

            return tagHelperOutput;
        }
    }
}