namespace Route.Generator.RouteAnalyzer
{
    using System.Collections.Generic;

    public interface IRouteAnalyzer
    {
        IEnumerable<RouteInfo> GetAllRouteInformations();
    }
}
