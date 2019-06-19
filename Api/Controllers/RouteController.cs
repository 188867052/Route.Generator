using Microsoft.AspNetCore.Mvc;
using Route.Generator.RouteAnalyzer;

namespace Api.Controllers
{
    public class RouteController : Controller
    {
        private readonly IRouteAnalyzer _routeAnalyzer;

        public RouteController(IRouteAnalyzer routeAnalyzer)
        {
            _routeAnalyzer = routeAnalyzer;
        }

        [HttpGet]
        [Route(Router.DefaultRoute)]
        public JsonResult ShowAllRoutes()
        {
            var infos = _routeAnalyzer.GetAllRouteInformations();
            return Json(infos);
        }
    }
}
