using System.Collections.Generic;

namespace Route.Generator.RouteAnalyzer
{
    public class RouteInfo
    {
        public RouteInfo()
        {
            Parameters = new List<ParameterInfo>();
            HttpMethod = "GET";
        }

        public string HttpMethod { get; set; }

        public string Area { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public IList<ParameterInfo> Parameters { get; set; }

        public string Path { get; set; }

        public string Namespace { get; set; }
    }
}
