namespace Route.Generator
{
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.DependencyInjection;

    public static class RouteAnalyzerExtensions
    {
        public static IRouteBuilder MapRouteAnalyzer(this IRouteBuilder routes)
        {
            routes.Routes.Add(new Router(routes.DefaultHandler, Router.DefaultRoute));
            routes.Routes.Add(new Router(routes.DefaultHandler, Router.DefaultRouteHtml));
            return routes;
        }

        public static IServiceCollection AddRouteAnalyzer(this IServiceCollection services)
        {
            services.AddSingleton<IRouteAnalyzer, RouteAnalyzer>();
            return services;
        }
    }
}
