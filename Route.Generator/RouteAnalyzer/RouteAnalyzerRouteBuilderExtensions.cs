namespace Route.Generator.RouteAnalyzer
{
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.DependencyInjection;

    public static class RouteAnalyzerRouteBuilderExtensions
    {
        public static IRouteBuilder MapRouteAnalyzer(this IRouteBuilder routes, string routePath)
        {
            routes.Routes.Add(new Router(routes.DefaultHandler, routePath));
            return routes;
        }
    }
}
