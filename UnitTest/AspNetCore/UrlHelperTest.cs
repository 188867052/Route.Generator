namespace Microsoft.AspNetCore.Mvc.Routing
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using Xunit.Abstractions;

    public class UrlHelperTest : UrlHelperTestBase
    {
        public UrlHelperTest(ITestOutputHelper tempOutput)
            : base(tempOutput)
        {
        }

        protected override IServiceProvider CreateServices()
        {
            var services = this.GetCommonServices();
            return services.BuildServiceProvider();
        }

        protected override IUrlHelper CreateUrlHelper(string appRoot, string host, string protocol)
        {
            var services = this.CreateServices();
            var httpContext = this.CreateHttpContext(services, appRoot, host, protocol);
            var actionContext = this.CreateActionContext(httpContext);
            var defaultRoutes = GetDefaultRoutes(services);
            actionContext.RouteData.Routers.Add(defaultRoutes);
            return new UrlHelper(actionContext);
        }

        protected override IUrlHelper CreateUrlHelperWithDefaultRoutes(
            string appRoot,
            string host,
            string protocol,
            string routeName,
            string template)
        {
            var services = this.CreateServices();
            var httpContext = this.CreateHttpContext(services, appRoot, host, protocol);
            var actionContext = this.CreateActionContext(httpContext);
            var router = GetDefaultRoutes(services, routeName, template);
            actionContext.RouteData.Routers.Add(router);
            return this.CreateUrlHelper(actionContext);
        }

        protected override IUrlHelper CreateUrlHelper(ActionContext actionContext)
        {
            return new UrlHelper(actionContext);
        }

        protected override IUrlHelper CreateUrlHelperWithDefaultRoutes(string appRoot, string host, string protocol)
        {
            var services = this.CreateServices();
            var context = this.CreateHttpContext(services, appRoot, host, protocol);

            var router = GetDefaultRoutes(services);
            var actionContext = this.CreateActionContext(context);
            actionContext.RouteData.Routers.Add(router);

            return this.CreateUrlHelper(actionContext);
        }

        protected override IUrlHelper CreateUrlHelper(
            string appRoot,
            string host,
            string protocol,
            string routeName,
            string template,
            object defaults)
        {
            var services = this.CreateServices();
            var routeBuilder = CreateRouteBuilder(services);
            routeBuilder.MapRoute(
                routeName,
                template,
                defaults);
            var router = routeBuilder.Build();
            var httpContext = this.CreateHttpContext(services, appRoot, host, protocol);
            var actionContext = this.CreateActionContext(httpContext);
            actionContext.RouteData.Routers.Add(router);
            return this.CreateUrlHelper(actionContext);
        }

        private static IRouter GetDefaultRoutes(IServiceProvider services)
        {
            return GetDefaultRoutes(services, "mockRoute", "/mockTemplate");
        }

        private static IRouter GetDefaultRoutes(
            IServiceProvider services,
            string mockRouteName,
            string mockTemplateValue)
        {
            var routeBuilder = CreateRouteBuilder(services);

            var target = new Mock<IRouter>(MockBehavior.Strict);
            target
                .Setup(router => router.GetVirtualPath(It.IsAny<VirtualPathContext>()))
                .Returns<VirtualPathContext>(context => null);
            routeBuilder.DefaultHandler = target.Object;

            routeBuilder.MapRoute(
                "OrdersApi",
                "api/orders/{id}",
                new RouteValueDictionary(new { controller = "Orders", action = "GetById" }));

            routeBuilder.MapRoute(
                string.Empty,
                "{controller}/{action}/{id}",
                new RouteValueDictionary(new { id = "defaultid" }));

            routeBuilder.MapRoute(
                "namedroute",
                "named/{controller}/{action}/{id}",
                new RouteValueDictionary(new { id = "defaultid" }));

            var mockHttpRoute = new Mock<IRouter>();
            mockHttpRoute
                .Setup(mock => mock.GetVirtualPath(It.Is<VirtualPathContext>(c => string.Equals(c.RouteName, mockRouteName))))
                .Returns(new VirtualPathData(mockHttpRoute.Object, mockTemplateValue));

            routeBuilder.Routes.Add(mockHttpRoute.Object);
            return routeBuilder.Build();
        }

        private static IRouteBuilder CreateRouteBuilder(IServiceProvider services)
        {
            var app = new Mock<IApplicationBuilder>();
            app
                .SetupGet(a => a.ApplicationServices)
                .Returns(services);

            return new RouteBuilder(app.Object)
            {
                DefaultHandler = new PassThroughRouter(),
            };
        }

        private class PassThroughRouter : IRouter
        {
            public VirtualPathData GetVirtualPath(VirtualPathContext context)
            {
                return null;
            }

            public Task RouteAsync(RouteContext context)
            {
                context.Handler = (c) => Task.FromResult(0);
                return Task.FromResult(false);
            }
        }
    }
}