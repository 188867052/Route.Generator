namespace Route.Generator
{
    using Microsoft.Extensions.DependencyInjection;

    public static class RouteAnalyzerExtensions
    {
        public const string DefaultRoute = "/routes";
        public const string DefaultRouteHtml = DefaultRoute + ".html";
        public const string DefaultRouteClass = DefaultRoute + ".class";

        public static IServiceCollection AddRouteAnalyzer(this IServiceCollection services)
        {
            services.AddSingleton<IRouteAnalyzer, RouteAnalyzer>();
            return services;
        }
    }
}
