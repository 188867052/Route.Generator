using System.Collections.Generic;
using System.Threading.Tasks;
using Route.Generator.RouteAnalyzer;

namespace Mvc.Routes
{
    public class Cache
    {
        public static Dictionary<string, RouteInfo> Dictionary = new Dictionary<string, RouteInfo>()
        {
            {Mvc.Routes.HomeRoute.Index, new RouteInfo
                {
                    HttpMethod = "GET",
                }
            },
            {Mvc.Routes.HomeRoute.About, new RouteInfo
                {
                    HttpMethod = "GET",
                }
            },
            {Mvc.Routes.HomeRoute.Contact, new RouteInfo
                {
                    HttpMethod = "GET",
                }
            },
            {Mvc.Routes.HomeRoute.Privacy, new RouteInfo
                {
                    HttpMethod = "GET",
                }
            },
            {Mvc.Routes.HomeRoute.Error, new RouteInfo
                {
                    HttpMethod = "GET",
                }
            },
        };
    }

    /// <summary>
    /// <see cref="Controllers.HomeController"/>
    /// </summary>
    public class HomeRoute
    {
        /// <summary>
        /// <see cref="Controllers.HomeController.Index"/>
        /// </summary>
        public const string Index = "/Admin/Home/Index";

        /// <summary>
        /// <see cref="Controllers.HomeController.About"/>
        /// </summary>
        public const string About = "/Admin/Home/About";

        /// <summary>
        /// <see cref="Controllers.HomeController.Contact"/>
        /// </summary>
        public const string Contact = "/Admin/Home/Contact";

        /// <summary>
        /// <see cref="Controllers.HomeController.Privacy"/>
        /// </summary>
        public const string Privacy = "/Admin/Home/Privacy";

        /// <summary>
        /// <see cref="Controllers.HomeController.Error"/>
        /// </summary>
        public const string Error = "/8D37DA4925BB";
    }
}
