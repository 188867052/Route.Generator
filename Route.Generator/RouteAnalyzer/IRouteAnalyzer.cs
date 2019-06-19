using System.Collections.Generic;

namespace Route.Generator.RouteAnalyzer
{
    public interface IRouteAnalyzer
    {
        IEnumerable<RouteInfo> GetAllRouteInformations();
    }
}
