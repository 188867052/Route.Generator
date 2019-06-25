namespace Route.Generator
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Routing;

    public class Router : IRouter
    {
        public const string DefaultRoute = "/routes";
        private readonly IRouter defaultRouter;
        private readonly string routePath;

        public Router(IRouter defaultRouter, string routePath)
        {
            this.defaultRouter = defaultRouter;
            this.routePath = routePath;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }

        public async Task RouteAsync(RouteContext context)
        {
            if (context.HttpContext.Request.Path == this.routePath)
            {
                var routeData = new RouteData(context.RouteData);
                routeData.Routers.Add(this.defaultRouter);
                routeData.Values["controller"] = "Route";
                routeData.Values["action"] = "ShowAllRoutes";
                context.RouteData = routeData;
                await this.defaultRouter.RouteAsync(context);
            }
        }
    }
}
