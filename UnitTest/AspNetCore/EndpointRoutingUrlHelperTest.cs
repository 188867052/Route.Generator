namespace UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Features;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.AspNetCore.Routing.Patterns;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Xunit;

    public class EndpointRoutingUrlHelperTest : UrlHelperTestBase
    {
        [Fact]
        public void RouteUrl_WithRouteName_GeneratesUrl_UsingDefaults()
        {
            // Arrange
            var endpoint1 = this.CreateEndpoint(
                "api/orders/{id}",
                defaults: new { controller = "Orders", action = "GetById" },
                requiredValues: new { controller = "Orders", action = "GetById" },
                routeName: "OrdersApi");
            var endpoint2 = this.CreateEndpoint(
                "api/orders",
                defaults: new { controller = "Orders", action = "GetAll" },
                requiredValues: new { controller = "Orders", action = "GetAll" },
                routeName: "OrdersApi");
            var urlHelper = this.CreateUrlHelper(new[] { endpoint1, endpoint2 });

            // Act
            var url = urlHelper.RouteUrl(
                routeName: "OrdersApi",
                values: new { });

            // Assert
            Assert.Equal("/" + endpoint2.RoutePattern.RawText, url);
        }

        [Fact]
        public void RouteUrl_WithRouteName_UsesAmbientValues()
        {
            // Arrange
            var endpoint1 = this.CreateEndpoint(
                "api/orders/{id}",
                defaults: new { controller = "Orders", action = "GetById" },
                requiredValues: new { controller = "Orders", action = "GetById" },
                routeName: "OrdersApi");

            var urlHelper = this.CreateUrlHelper(new[] { endpoint1 });

            // Set the endpoint feature and current context just as a normal request to MVC app would be
            var endpointFeature = new EndpointSelectorContext();
            urlHelper.ActionContext.HttpContext.Features.Set<IEndpointFeature>(endpointFeature);
            urlHelper.ActionContext.HttpContext.Features.Set<IRouteValuesFeature>(endpointFeature);
            endpointFeature.Endpoint = endpoint1;
            endpointFeature.RouteValues = new RouteValueDictionary
            {
                ["controller"] = "Orders",
                ["action"] = "GetById",
                ["id"] = "500",
            };

            // Act
            var url = urlHelper.RouteUrl(
                routeName: "OrdersApi",
                values: new { });

            // Assert
            Assert.Equal("/api/orders/500", url);
        }

        [Fact]
        public void RouteUrl_WithRouteName_UsesSuppliedValue_OverridingAmbientValue()
        {
            // Arrange
            var endpoint1 = this.CreateEndpoint(
                "api/orders/{id}",
                defaults: new { controller = "Orders", action = "GetById" },
                requiredValues: new { controller = "Orders", action = "GetById" },
                routeName: "OrdersApi");
            var endpoint2 = this.CreateEndpoint(
                "api/orders",
                defaults: new { controller = "Orders", action = "GetAll" },
                requiredValues: new { controller = "Orders", action = "GetAll" },
                routeName: "OrdersApi");
            var urlHelper = this.CreateUrlHelper(new[] { endpoint1, endpoint2 });
            urlHelper.ActionContext.RouteData.Values["id"] = "500";

            // Act
            var url = urlHelper.RouteUrl(
                routeName: "OrdersApi",
                values: new { id = "10" });

            // Assert
            Assert.Equal("/api/orders/10", url);
        }

        [Fact]
        public void RouteUrl_DoesNotGenerateLink_ToEndpointsWithSuppressLinkGeneration()
        {
            // Arrange
            var endpoint = this.CreateEndpoint(
                "Home/Index",
                defaults: new { controller = "Home", action = "Index" },
                requiredValues: new { controller = "Home", action = "Index" },
                metadataCollection: new EndpointMetadataCollection(new[] { new SuppressLinkGenerationMetadata() }));
            var urlHelper = this.CreateUrlHelper(new[] { endpoint });

            // Act
            var url = urlHelper.RouteUrl(new { controller = "Home", action = "Index" });

            // Assert
            Assert.Null(url);
        }

        protected override IUrlHelper CreateUrlHelper(string appRoot, string host, string protocol)
        {
            return this.CreateUrlHelper(Enumerable.Empty<RouteEndpoint>(), appRoot, host, protocol);
        }

        protected override IUrlHelper CreateUrlHelperWithDefaultRoutes(string appRoot, string host, string protocol)
        {
            return this.CreateUrlHelper(this.GetDefaultEndpoints(), appRoot, host, protocol);
        }

        protected override IUrlHelper CreateUrlHelperWithDefaultRoutes(
            string appRoot,
            string host,
            string protocol,
            string routeName,
            string template)
        {
            var endpoints = this.GetDefaultEndpoints();
            endpoints.Add(this.CreateEndpoint(template, routeName: routeName));
            return this.CreateUrlHelper(endpoints, appRoot, host, protocol);
        }

        protected override IUrlHelper CreateUrlHelper(ActionContext actionContext)
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
            // TODO Assert.IsType<EndpointRoutingUrlHelper>(urlHelper);
            return urlHelper;
        }

        protected override IServiceProvider CreateServices()
        {
            return this.CreateServices(Enumerable.Empty<Endpoint>());
        }

        protected override IUrlHelper CreateUrlHelper(
            string appRoot,
            string host,
            string protocol,
            string routeName,
            string template,
            object defaults)
        {
            var endpoint = this.CreateEndpoint(template, new RouteValueDictionary(defaults), routeName: routeName);
            var services = this.CreateServices(new[] { endpoint });
            var httpContext = this.CreateHttpContext(services, appRoot: "", host: null, protocol: null);
            var actionContext = this.CreateActionContext(httpContext);
            return this.CreateUrlHelper(actionContext);
        }

        private IUrlHelper CreateUrlHelper(IEnumerable<RouteEndpoint> endpoints, ActionContext actionContext = null)
        {
            var serviceProvider = this.CreateServices(endpoints);
            var httpContext = this.CreateHttpContext(serviceProvider, null, null, "http");
            actionContext = actionContext ?? this.CreateActionContext(httpContext);
            return this.CreateUrlHelper(actionContext);
        }

        private IUrlHelper CreateUrlHelper(
            IEnumerable<RouteEndpoint> endpoints,
            string appRoot,
            string host,
            string protocol)
        {
            var serviceProvider = this.CreateServices(endpoints);
            var httpContext = this.CreateHttpContext(serviceProvider, appRoot, host, protocol);
            var actionContext = this.CreateActionContext(httpContext);
            return this.CreateUrlHelper(actionContext);
        }

        private List<RouteEndpoint> GetDefaultEndpoints()
        {
            var endpoints = new List<RouteEndpoint>();
            endpoints.Add(
                this.CreateEndpoint(
                    "home/newaction/{id}",
                    defaults: new { id = "defaultid", controller = "home", action = "newaction" },
                    requiredValues: new { controller = "home", action = "newaction" },
                    order: 1));
            endpoints.Add(
                this.CreateEndpoint(
                    "home/contact/{id}",
                    defaults: new { id = "defaultid", controller = "home", action = "contact" },
                    requiredValues: new { controller = "home", action = "contact" },
                    order: 2));
            endpoints.Add(
                this.CreateEndpoint(
                    "home2/newaction/{id}",
                    defaults: new { id = "defaultid", controller = "home2", action = "newaction" },
                    requiredValues: new { controller = "home2", action = "newaction" },
                    order: 3));
            endpoints.Add(
                this.CreateEndpoint(
                    "home2/contact/{id}",
                    defaults: new { id = "defaultid", controller = "home2", action = "contact" },
                    requiredValues: new { controller = "home2", action = "contact" },
                    order: 4));
            endpoints.Add(
                this.CreateEndpoint(
                    "home3/contact/{id}",
                    defaults: new { id = "defaultid", controller = "home3", action = "contact" },
                    requiredValues: new { controller = "home3", action = "contact" },
                    order: 5));
            endpoints.Add(
                this.CreateEndpoint(
                    "named/home/newaction/{id}",
                    defaults: new { id = "defaultid", controller = "home", action = "newaction" },
                    requiredValues: new { controller = "home", action = "newaction" },
                    order: 6,
                    routeName: "namedroute"));
            endpoints.Add(
                this.CreateEndpoint(
                    "named/home2/newaction/{id}",
                    defaults: new { id = "defaultid", controller = "home2", action = "newaction" },
                    requiredValues: new { controller = "home2", action = "newaction" },
                    order: 7,
                    routeName: "namedroute"));
            endpoints.Add(
                this.CreateEndpoint(
                    "named/home/contact/{id}",
                    defaults: new { id = "defaultid", controller = "home", action = "contact" },
                    requiredValues: new { controller = "home", action = "contact" },
                    order: 8,
                    routeName: "namedroute"));
            endpoints.Add(
                this.CreateEndpoint(
                    "api/orders/{id}",
                    defaults: new { controller = "Orders", action = "GetById" },
                    requiredValues: new { controller = "Orders", action = "GetById" },
                    order: 10,
                    routeName: "OrdersApi"));
            return endpoints;
        }

        private RouteEndpoint CreateEndpoint(
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

        private IServiceProvider CreateServices(IEnumerable<Endpoint> endpoints)
        {
            if (endpoints == null)
            {
                endpoints = Enumerable.Empty<Endpoint>();
            }

            var services = this.GetCommonServices();
            services.AddRouting();
            services.TryAddEnumerable(
                ServiceDescriptor.Singleton<EndpointDataSource>(new DefaultEndpointDataSource(endpoints)));
            services.TryAddSingleton<IUrlHelperFactory, UrlHelperFactory>();
            return services.BuildServiceProvider();
        }
    }
}
