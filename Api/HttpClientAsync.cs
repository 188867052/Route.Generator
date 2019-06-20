using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net.Http;
using HttpMethod = Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod;
using Route.Generator.RouteAnalyzer;
using Api;
using System.Web;
using Xunit.Abstractions;

namespace Core.Api.Framework
{
    public static class HttpClientAsync
    {
        private static string BaseAddress = "http://localhost:27634/";
        public static ITestOutputHelper _output;
        public static HttpClient CreateInstance()
        {
            return new HttpClient() { BaseAddress = new Uri(BaseAddress) };
        }

        public static async Task<T> Async<T>(RouteInfo routeInfo, params object[] data)
        {
            using (HttpClient httpClient = CreateInstance())
            {
                string json = await ExcuteAsync(httpClient, routeInfo, data);
                _output.WriteLine($"Response Data: {json}");
                T model = JsonConvert.DeserializeObject<T>(json);

                return model;
            }
        }
      
        private static async Task<string> PostAsync(HttpClient httpClient, string url, params object[] data)
        {
            var content = JsonConvert.SerializeObject(data[0]);
            _output.WriteLine($"Request Route: {url}");
            _output.WriteLine($"Request Data: {JsonConvert.SerializeObject(data, Formatting.Indented)}");
            using (StringContent httpContent = new StringContent(content))
            {
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                using (HttpResponseMessage httpResponse = await httpClient.PostAsync(url, httpContent))
                {
                    return await httpResponse.Content.ReadAsStringAsync();
                }
            }
        }

        private static async Task<string> GetAsync(HttpClient httpClient, string url, params object[] data)
        {
            _output.WriteLine($"Request Route: {url}");
            _output.WriteLine($"Request Data: {JsonConvert.SerializeObject(data, Formatting.Indented)}");
            using (HttpResponseMessage httpResponse = await httpClient.GetAsync(url))
            {
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }

        private static string GenerateUrl(RouteInfo RouteInfo, params object[] data)
        {
            string url = RouteInfo.Path;
            IList<ParameterInfo> parameterInfos = RouteInfo.Parameters;

            // Attribute Constraint Route.
            MatchCollection matches = Regex.Matches(RouteInfo.Path, "[^/]+[{}]");
            int constraintCount = matches.Count;
            if (matches != null && constraintCount > 0)
            {
                for (int i = 0; i < constraintCount; i++)
                {
                    var constraint = matches[i].Value;
                    string name = constraint.Trim('{', '}');
                    Match match = Regex.Match(name, "[^{=?]+");
                    name = match.Value;
                    var parameterInfo = parameterInfos.FirstOrDefault(o => o.Name == name);
                    int dataIndex = parameterInfos.IndexOf(parameterInfo);
                    object value = data.ElementAt(dataIndex);
                    if (value == default)
                    {
                        value = Extention.GetDefaultValueByName(parameterInfo.Type);
                    }
                    else
                    {
                        value = HttpUtility.UrlEncode(value.ToString());
                    }

                    var replaced = constraint.Replace(parameterInfos.ElementAt(i).Name, (string)value);
                    url = url.Replace(constraint, (string)value);
                }
            }

            if (data != null && data.Length - constraintCount > 0)
            {
                for (int i = constraintCount; i < data.Length; i++)
                {
                    var value = data[i];
                    if (value == default)
                    {
                        value = Extention.GetDefaultValueByName(parameterInfos[i].Type);
                        parameterInfos[i].Value = (string)value;
                    }
                    else
                    {
                        var valueStr = value.ToString();
                        if (valueStr.Contains("{") && valueStr.Contains("}") && valueStr.Contains("="))
                        {
                            var keyValuePair = valueStr.Split(',');
                            foreach (var item in keyValuePair)
                            {
                                var array = item.Split('=');
                                string k = array[0].Trim('{', ' ');
                                string v = array[1].Trim('}', ' ');
                                parameterInfos.FirstOrDefault(o => o.Name == k).Value = v;
                            }
                        }
                        else
                        {
                            parameterInfos[i].Value = data[i].ToString();
                        }
                    }
                }
            }

            var NoConstraintParameterInfos = parameterInfos.Skip(constraintCount);
            url = url
                + (NoConstraintParameterInfos.Count() > 0 ? "?" : "")
                + string.Join("&", NoConstraintParameterInfos.Select(o => $"{o.Name}={HttpUtility.UrlEncode(o.Value)}"));

            return url;
        }

        private static Task<string> ExcuteAsync(HttpClient httpClient, RouteInfo RouteInfo, params object[] data)
        {
            Task<string> json;
            var httpMethod = (HttpMethod)Enum.Parse(typeof(HttpMethod), RouteInfo.HttpMethod, true);
            switch (httpMethod)
            {
                case HttpMethod.Get:
                    string url = GenerateUrl(RouteInfo, data);
                    json = GetAsync(httpClient, url, data);
                    break;
                case HttpMethod.Post:
                    json = PostAsync(httpClient, RouteInfo.Path, data);
                    break;
                default:
                    throw new HttpRequestException($"Unsupported Http Method: {httpMethod}.");
            }

            return json;
        }
    }
}
