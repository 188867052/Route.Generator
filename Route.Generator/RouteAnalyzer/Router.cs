using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace Route.Generator.RouteAnalyzer
{
    public class Router : IRouter
    {
        public const string DefaultRoute = "/routes";
        private readonly IRouter _defaultRouter;
        private readonly string _routePath;

        public Router(IRouter defaultRouter, string routePath)
        {
            _defaultRouter = defaultRouter;
            _routePath = routePath;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }

        public async Task RouteAsync(RouteContext context)
        {
            if (context.HttpContext.Request.Path == _routePath)
            {
                var routeData = new RouteData(context.RouteData);
                routeData.Routers.Add(_defaultRouter);
                routeData.Values["controller"] = "Route"; ;
                routeData.Values["action"] = "ShowAllRoutes"; ;
                context.RouteData = routeData;
                await _defaultRouter.RouteAsync(context);
            }
        }
    }
}
