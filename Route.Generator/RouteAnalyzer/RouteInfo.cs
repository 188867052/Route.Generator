namespace Route.Generator.RouteAnalyzer
{
    using System.Collections.Generic;

    public class RouteInfo
    {
        public RouteInfo()
        {
            this.Parameters = new List<ParameterInfo>();
            this.HttpMethods = "GET";
        }

        public string HttpMethods { get; set; }

        public string Area { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public IList<ParameterInfo> Parameters { get; set; }

        public string Path { get; set; }

        public string Namespace { get; set; }
    }
}
