namespace Route.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Web;
    using Newtonsoft.Json;
    using HttpMethod = Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod;

    public static class HttpClientAsync
    {
        private static readonly string BaseAddress;

        static HttpClientAsync()
        {
            BaseAddress = "http://localhost:27634/";
        }

        public static HttpClient CreateInstance()
        {
            return new HttpClient() { BaseAddress = new Uri(BaseAddress) };
        }

        public static async Task<T> Async<T>(RouteInfo routeInfo, params object[] data)
        {
            using (HttpClient httpClient = CreateInstance())
            {
                string json = await GetResponseMessageAsync(httpClient, routeInfo, data);
                T model = JsonConvert.DeserializeObject<T>(json);

                return model;
            }
        }

        private static void PrepareStringContent(out StringContent httpContent, IList<string> constraintNameList, RouteInfo routeInfo, params object[] data)
        {
            object stringContent = new object();
            if (constraintNameList.Count == 0)
            {
                stringContent = data[0];
            }
            else
            {
                for (int i = 0; i < constraintNameList.Count; i++)
                {
                    var index = routeInfo.Parameters.IndexOf(routeInfo.Parameters.FirstOrDefault(o => o.Name != constraintNameList[i]));
                    stringContent = data[index];
                }
            }

            string content = JsonConvert.SerializeObject(stringContent);
            httpContent = new StringContent(content);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        private static async Task<string> GetResponseMessageAsync(HttpClient httpClient, RouteInfo routeInfo, params object[] data)
        {
            HttpResponseMessage httpResponseMessage;
            StringContent httpContent;
            PrepareConstraintParameters(out string url, out IList<string> constraintNameList, routeInfo, data);
            var httpMethod = (HttpMethod)Enum.Parse(typeof(HttpMethod), routeInfo.HttpMethods, true);
            switch (httpMethod)
            {
                case HttpMethod.Get:
                    PrepareNoneConstraintParameters(out url, routeInfo, constraintNameList, url, data);
                    httpResponseMessage = await httpClient.GetAsync(url);
                    break;
                case HttpMethod.Post:
                    PrepareStringContent(out httpContent, constraintNameList, routeInfo, data);
                    httpResponseMessage = await httpClient.PostAsync(url, httpContent);
                    httpContent.Dispose();
                    break;
                case HttpMethod.Patch:
                    PrepareStringContent(out httpContent, constraintNameList, routeInfo, data);
                    httpResponseMessage = await httpClient.PatchAsync(url, httpContent);
                    httpContent.Dispose();
                    break;
                case HttpMethod.Delete:
                    PrepareNoneConstraintParameters(out url, routeInfo, constraintNameList, url, data);
                    httpResponseMessage = await httpClient.DeleteAsync(url);
                    break;
                case HttpMethod.Put:
                    PrepareStringContent(out httpContent, constraintNameList, routeInfo, data);
                    httpResponseMessage = await httpClient.PutAsync(url, httpContent);
                    httpContent.Dispose();
                    break;
                default:
                    throw new HttpRequestException($"Waiting for Support! Http Method: {httpMethod}.");
            }

            var message = await httpResponseMessage.Content.ReadAsStringAsync();
            httpResponseMessage.Dispose();
            return message;
        }

        private static void PrepareConstraintParameters(out string constraintUrl, out IList<string> constraintNameList, RouteInfo routeInfo, params object[] data)
        {
            string url = routeInfo.Path;
            constraintNameList = new List<string>();

            // Attribute Constraint Route.
            var matches = Regex.Matches(routeInfo.Path, "[^/]+[{}]");
            if (matches != null && matches.Count > 0)
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    var constraint = matches[i].Value;
                    string name = constraint.Trim('{', '}');
                    Match match = Regex.Match(name, "[^{=?]+");
                    name = match.Value;
                    constraintNameList.Add(name);
                    var parameterInfo = routeInfo.Parameters.FirstOrDefault(o => o.Name == name);
                    int dataIndex = routeInfo.Parameters.IndexOf(parameterInfo);
                    object value = data.ElementAt(dataIndex);
                    if (value == default)
                    {
                        value = Extention.GetDefaultValueByName(parameterInfo.Type);
                    }
                    else
                    {
                        value = HttpUtility.UrlEncode(value.ToString());
                    }

                    var replaced = constraint.Replace(routeInfo.Parameters.ElementAt(i).Name, (string)value);
                    url = url.Replace(constraint, (string)value);
                }
            }

            constraintUrl = url;
        }

        private static void PrepareNoneConstraintParameters(out string constraintUrl, RouteInfo routeInfo, IList<string> constraintNameList, string url, params object[] data)
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
    }
}
