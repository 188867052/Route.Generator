namespace Mvc.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Route.Generator.RouteAnalyzer;

    public class RouteController : Controller
    {
        private readonly IRouteAnalyzer routeAnalyzer;

        public RouteController(IRouteAnalyzer routeAnalyzer)
        {
            this.routeAnalyzer = routeAnalyzer;
        }

        [HttpGet]
        [Route(Router.DefaultRoute)]
        public JsonResult ShowAllRoutes()
        {
            var infos = this.routeAnalyzer.GetAllRouteInformations();
            return this.Json(infos);
        }
    }
}
