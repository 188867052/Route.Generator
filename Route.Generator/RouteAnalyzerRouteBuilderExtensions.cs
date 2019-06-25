namespace Route.Generator
{
    using Microsoft.AspNetCore.Routing;

    public static class RouteAnalyzerRouteBuilderExtensions
    {
        public static IRouteBuilder MapRouteAnalyzer(this IRouteBuilder routes, string routePath)
        {
            routes.Routes.Add(new Router(routes.DefaultHandler, routePath));
            return routes;
        }
    }
}
