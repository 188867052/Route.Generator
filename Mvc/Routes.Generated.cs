using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Route.Generator;
using Route.Generator.RouteAnalyzer;

namespace Mvc.Routes
{
    /// <summary>
    /// <see cref="Controllers.AboutController"/>
    /// </summary>
    public class AboutRoute
    {
        /// <summary>
        /// <see cref="Controllers.AboutController.Me"/>
        /// </summary>
        public const string Me = "/mvc";

        /// <summary>
        /// <see cref="Controllers.AboutController.Company"/>
        /// </summary>
        public const string Company = "/mvc/company";
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

    /// <summary>
    /// <see cref="Controllers.SimpleController"/>
    /// </summary>
    public class SimpleRoute
    {
        /// <summary>
        /// <see cref="Controllers.SimpleController.Me"/>
        /// </summary>
        public const string Me = "/Simple/me";

        /// <summary>
        /// <see cref="Controllers.SimpleController.Company"/>
        /// </summary>
        public const string Company = "/Simple/company";
    }
}
