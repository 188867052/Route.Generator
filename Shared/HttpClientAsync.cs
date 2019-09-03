namespace Route.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Features;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Abstractions;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.AspNetCore.Routing.Patterns;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.Extensions.ObjectPool;
    using Newtonsoft.Json;
    using HttpMethod = Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod;

    public static class HttpClientAsync
    {
        private static readonly string BaseAddress;

        static HttpClientAsync()
        {
            BaseAddress = "http://47.105.214.235:82/";
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

        private static RouteEndpoint CreateEndpoint(
         string template,
         object defaults = null,
         object requiredValues = null,
         int order = 0,
         string routeName = null,
         EndpointMetadataCollection metadataCollection = null)
        {
            if (metadataCollection == null)
            {
                metadataCollection = new EndpointMetadataCollection(
                    new RouteValuesAddressMetadata(routeName, new RouteValueDictionary(requiredValues)));
            }

            return new RouteEndpoint(
                (httpContext) => Task.CompletedTask,
                RoutePatternFactory.Parse(template, defaults, parameterPolicies: null),
                order,
                metadataCollection,
                null);
        }

        private static IServiceCollection GetCommonServices()
        {
            var services = new ServiceCollection();
            services.AddOptions();
            services.AddLogging();
            services.AddRouting();
            services
                .AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>()
                .AddSingleton(UrlEncoder.Default);
            return services;
        }

        private static HttpContext CreateHttpContext(
          IServiceProvider services,
          string appRoot,
          string host,
          string protocol)
        {
            appRoot = string.IsNullOrEmpty(appRoot) ? string.Empty : appRoot;
            host = string.IsNullOrEmpty(host) ? "localhost" : host;

            var context = new DefaultHttpContext();
            context.RequestServices = services;
            context.Request.PathBase = new PathString(appRoot);
            context.Request.Host = new HostString(host);
            context.Request.Scheme = protocol;
            return context;
        }

        private static IServiceProvider CreateServices(IEnumerable<Endpoint> endpoints)
        {
            if (endpoints == null)
            {
                endpoints = Enumerable.Empty<Endpoint>();
            }

            var services = GetCommonServices();
            services.AddRouting();
            services.TryAddEnumerable(ServiceDescriptor.Singleton<EndpointDataSource>(new DefaultEndpointDataSource(endpoints)));
            services.TryAddSingleton<IUrlHelperFactory, UrlHelperFactory>();
            return services.BuildServiceProvider();
        }

        private static ActionContext CreateActionContext(HttpContext httpContext, RouteData routeData = null)
        {
            routeData = routeData ?? new RouteData();
            return new ActionContext(httpContext, routeData, new ActionDescriptor());
        }

        private static IUrlHelper CreateUrlHelper(IEnumerable<RouteEndpoint> endpoints, ActionContext actionContext = null)
        {
            var serviceProvider = CreateServices(endpoints);
            var httpContext = CreateHttpContext(serviceProvider, null, null, "http");
            actionContext = actionContext ?? CreateActionContext(httpContext);
            return CreateUrlHelper(actionContext);
        }

        private static IUrlHelper CreateUrlHelper(ActionContext actionContext)
        {
            var httpContext = actionContext.HttpContext;
            httpContext.Features.Set<IEndpointFeature>(new EndpointSelectorContext()
            {
                Endpoint = new Endpoint(
                    context => Task.CompletedTask,
                    EndpointMetadataCollection.Empty,
                    null),
            });

            var urlHelperFactory = httpContext.RequestServices.GetRequiredService<IUrlHelperFactory>();
            var urlHelper = urlHelperFactory.GetUrlHelper(actionContext);
            return urlHelper;
        }

        private static void PrepareConstraintParameters(out string constraintUrl, out IList<string> constraintNameList, RouteInfo routeInfo, params object[] data)
        {
            var endpoint = CreateEndpoint(routeInfo.Path, routeName: routeInfo.Path);
            constraintNameList = endpoint.RoutePattern.Parameters.Select(o => o.Name).ToList();
            var urlHelper = CreateUrlHelper(new[] { endpoint });

            // Set the endpoint feature and current context just as a normal request to MVC app would be
            var endpointFeature = new EndpointSelectorContext();
            urlHelper.ActionContext.HttpContext.Features.Set<IEndpointFeature>(endpointFeature);
            urlHelper.ActionContext.HttpContext.Features.Set<IRouteValuesFeature>(endpointFeature);
            endpointFeature.Endpoint = endpoint;
            endpointFeature.RouteValues = new RouteValueDictionary();
            foreach (var item in routeInfo.Parameters)
            {
                int dataIndex = routeInfo.Parameters.IndexOf(item);
                object value = data.ElementAt(dataIndex);
                endpointFeature.RouteValues.TryAdd(item.Name, value);
            }

            constraintUrl = urlHelper.RouteUrl(routeName: routeInfo.Path, values: endpointFeature.RouteValues);
        }
    }
}
