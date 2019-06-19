﻿using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Route.Generator.RouteAnalyzer
{
    public static class RouteAnalyzerServiceCollectionExtensions
    {
        public static IServiceCollection AddRouteAnalyzer(this IServiceCollection services)
        {
            services.AddSingleton<IRouteAnalyzer, RouteAnalyzer>();
            return services;
        }
    }

    public static class RouteAnalyzerRouteBuilderExtensions
    {
        public static IRouteBuilder MapRouteAnalyzer(this IRouteBuilder routes, string routePath)
        {
            routes.Routes.Add(new Router(routes.DefaultHandler, routePath));
            return routes;
        }
    }
}
