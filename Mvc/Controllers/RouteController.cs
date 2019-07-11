namespace Mvc.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Route.Generator;

    public class RouteController : Controller
    {
        private readonly IRouteAnalyzer routeAnalyzer;

        public RouteController(IRouteAnalyzer routeAnalyzer)
        {
            this.routeAnalyzer = routeAnalyzer;
        }

        [HttpGet]
        [Route(RouteAnalyzerExtensions.DefaultRoute)]
        public JsonResult ShowAllRoutes()
        {
            var infos = this.routeAnalyzer.GetAllRouteInfo();
            return this.Json(infos);
        }
    }
}
