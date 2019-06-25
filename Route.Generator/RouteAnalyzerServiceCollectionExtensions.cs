namespace Route.Generator
{
    using Microsoft.Extensions.DependencyInjection;

    public static class RouteAnalyzerServiceCollectionExtensions
    {
        public static IServiceCollection AddRouteAnalyzer(this IServiceCollection services)
        {
            services.AddSingleton<IRouteAnalyzer, RouteAnalyzer>();
            return services;
        }
    }
}
