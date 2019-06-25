namespace Route.Generator
{
    using System.Collections.Generic;

    public interface IRouteAnalyzer
    {
        IEnumerable<RouteInfo> GetAllRouteInformations();
    }
}
