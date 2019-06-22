namespace Core.Api.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Web;
    using global::Api;
    using Newtonsoft.Json;
    using Route.Generator.RouteAnalyzer;
    using Xunit.Abstractions;
    using HttpMethod = Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod;

    public static class HttpClientAsync
    {
        private static readonly string BaseAddress = "http://localhost:27634/";

        public static ITestOutputHelper Output { get; set; }

        public static HttpClient CreateInstance()
        {
            return new HttpClient() { BaseAddress = new Uri(BaseAddress) };
        }

        public static async Task<T> Async<T>(RouteInfo routeInfo, params object[] data)
        {
            using (HttpClient httpClient = CreateInstance())
            {
                string json = await ExcuteAsync(httpClient, routeInfo, data);
                T model = JsonConvert.DeserializeObject<T>(json);

                return model;
            }
        }

        private static async Task<string> PostAsync(HttpClient httpClient, RouteInfo routeInfo, params object[] data)
        {
            string url = GenerateUrl(routeInfo, out IList<string> constraintNameList, data);
            object postContent = new object();
            if (constraintNameList.Count == 0)
            {
                postContent = data[0];
            }
            else
            {
                for (int i = 0; i < constraintNameList.Count; i++)
                {
                    var index = routeInfo.Parameters.IndexOf(routeInfo.Parameters.FirstOrDefault(o => o.Name != constraintNameList[i]));
                    postContent = data[index];
                }
            }

            // TODO
            string content = JsonConvert.SerializeObject(postContent);
            Output.WriteLine($"Request Url: {url}");
            Output.WriteLine($"Request Data: {JsonConvert.SerializeObject(postContent, Formatting.Indented)}");
            using (StringContent httpContent = new StringContent(content))
            {
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                using (HttpResponseMessage httpResponse = await httpClient.PostAsync(url, httpContent))
                {
                    return await httpResponse.Content.ReadAsStringAsync();
                }
            }
        }

        private static async Task<string> PatchAsync(HttpClient httpClient, RouteInfo routeInfo, params object[] data)
        {
            string url = GenerateUrl(routeInfo, out IList<string> constraintNameList, data);
            object postContent = new object();
            if (constraintNameList.Count == 0)
            {
                postContent = data[0];
            }
            else
            {
                for (int i = 0; i < constraintNameList.Count; i++)
                {
                    var index = routeInfo.Parameters.IndexOf(routeInfo.Parameters.FirstOrDefault(o => o.Name != constraintNameList[i]));
                    postContent = data[index];
                }
            }

            // TODO
            string content = JsonConvert.SerializeObject(postContent);
            Output.WriteLine($"Request Url: {url}");
            Output.WriteLine($"Request Data: {JsonConvert.SerializeObject(postContent, Formatting.Indented)}");
            using (StringContent httpContent = new StringContent(content))
            {
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                using (HttpResponseMessage httpResponse = await httpClient.PatchAsync(url, httpContent))
                {
                    return await httpResponse.Content.ReadAsStringAsync();
                }
            }
        }

        private static async Task<string> PutAsync(HttpClient httpClient, RouteInfo routeInfo, params object[] data)
        {
            string url = GenerateUrl(routeInfo, out IList<string> constraintNameList, data);
            object postContent = new object();
            if (constraintNameList.Count == 0)
            {
                postContent = data[0];
            }
            else
            {
                for (int i = 0; i < constraintNameList.Count; i++)
                {
                    var index = routeInfo.Parameters.IndexOf(routeInfo.Parameters.FirstOrDefault(o => o.Name != constraintNameList[i]));
                    postContent = data[index];
                }
            }

            // TODO
            string content = JsonConvert.SerializeObject(postContent);
            Output.WriteLine($"Request Url: {url}");
            Output.WriteLine($"Request Data: {JsonConvert.SerializeObject(postContent, Formatting.Indented)}");
            using (StringContent httpContent = new StringContent(content))
            {
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                using (HttpResponseMessage httpResponse = await httpClient.PutAsync(url, httpContent))
                {
                    return await httpResponse.Content.ReadAsStringAsync();
                }
            }
        }

        private static async Task<string> DeleteAsync(HttpClient httpClient, string url, params object[] data)
        {
            Output.WriteLine($"Request Url: {url}");
            Output.WriteLine($"Request Data: {JsonConvert.SerializeObject(data, Formatting.Indented)}");
            using (HttpResponseMessage httpResponse = await httpClient.DeleteAsync(url))
            {
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }

        private static async Task<string> GetAsync(HttpClient httpClient, string url, params object[] data)
        {
            Output.WriteLine($"Request Url: {url}");
            Output.WriteLine($"Request Data: {JsonConvert.SerializeObject(data, Formatting.Indented)}");
            using (HttpResponseMessage httpResponse = await httpClient.GetAsync(url))
            {
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }

        private static void PreAttributeConstraintParameters(RouteInfo routeInfo, out string constraintUrl, out IList<string> constraintNameList, params object[] data)
        {
            string url = routeInfo.Path;
            IList<ParameterInfo> parameterInfos = routeInfo.Parameters;
            constraintNameList = new List<string>();

            // Attribute Constraint Route.
            var matches = Regex.Matches(routeInfo.Path, "[^/]+[{}]");
            int constraintCount = matches.Count;
            if (matches != null && constraintCount > 0)
            {
                for (int i = 0; i < constraintCount; i++)
                {
                    var constraint = matches[i].Value;
                    string name = constraint.Trim('{', '}');
                    Match match = Regex.Match(name, "[^{=?]+");
                    name = match.Value;
                    constraintNameList.Add(name);
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

            constraintUrl = url;
        }

        private static void PreNoneAttributeConstraintParameters(RouteInfo routeInfo, IList<string> constraintNameList, string url, out string constraintUrl, params object[] data)
        {
            if (data != null && data.Length > 0)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    var value = data[i];
                    if (value == default)
                    {
                        value = Extention.GetDefaultValueByName(routeInfo.Parameters[i].Type);
                        routeInfo.Parameters[i].Value = (string)value;
                    }
                    else
                    {
                        // Support dynamic object;
                        var valueStr = value.ToString();
                        if (valueStr.Contains("{") && valueStr.Contains("}") && valueStr.Contains("="))
                        {
                            var keyValuePair = valueStr.Split(',');
                            foreach (var item in keyValuePair)
                            {
                                var array = item.Split('=');
                                string k = array[0].Trim('{', ' ');
                                string v = array[1].Trim('}', ' ');
                                routeInfo.Parameters.FirstOrDefault(o => o.Name == k).Value = v;
                            }
                        }
                        else
                        {
                            routeInfo.Parameters[i].Value = data[i].ToString();
                        }
                    }
                }
            }

            var noConstraintParameterInfos = routeInfo.Parameters.Where(o => !constraintNameList.Contains(o.Name));
            constraintUrl = url
                + (noConstraintParameterInfos.Count() > 0 ? "?" : string.Empty)
                + string.Join("&", noConstraintParameterInfos.Select(o => $"{o.Name}={HttpUtility.UrlEncode(o.Value)}"));
        }

        private static string GenerateUrl(RouteInfo routeInfo, out IList<string> constraintNameList, params object[] data)
        {
            PreAttributeConstraintParameters(routeInfo, out string url, out constraintNameList, data);
            if (routeInfo.HttpMethod.ToUpper() != "GET" && routeInfo.HttpMethod.ToUpper() != "DELETE")
            {
                return url;
            }

            PreNoneAttributeConstraintParameters(routeInfo, constraintNameList, url, out url, data);

            return url;
        }

        private static Task<string> ExcuteAsync(HttpClient httpClient, RouteInfo routeInfo, params object[] data)
        {
            Task<string> json;
            var httpMethod = (HttpMethod)Enum.Parse(typeof(HttpMethod), routeInfo.HttpMethod, true);
            switch (httpMethod)
            {
                case HttpMethod.Get:
                    {
                        string url = GenerateUrl(routeInfo, out _, data);
                        json = GetAsync(httpClient, url, data);
                        break;
                    }

                case HttpMethod.Post:
                    {
                        json = PostAsync(httpClient, routeInfo, data);
                        break;
                    }

                case HttpMethod.Patch:
                    {
                        json = PatchAsync(httpClient, routeInfo, data);
                        break;
                    }

                case HttpMethod.Delete:
                    {
                        string url = GenerateUrl(routeInfo, out _, data);
                        json = DeleteAsync(httpClient, url, data);
                        break;
                    }

                case HttpMethod.Put:
                    {
                        json = PutAsync(httpClient, routeInfo, data);
                        break;
                    }

                default:
                    throw new HttpRequestException($"Waiting for Support! Http Method: {httpMethod}.");
            }

            return json;
        }
    }
}
