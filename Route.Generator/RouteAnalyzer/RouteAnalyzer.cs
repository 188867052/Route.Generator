using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Route.Generator.RouteAnalyzer
{
    public class RouteAnalyzer : IRouteAnalyzer
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public RouteAnalyzer(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        public IEnumerable<RouteInfo> GetAllRouteInformations()
        {
            List<RouteInfo> list = new List<RouteInfo>();

            var routeCollection = _actionDescriptorCollectionProvider.ActionDescriptors.Items;
            foreach (ActionDescriptor route in routeCollection)
            {
                RouteInfo info = new RouteInfo();

                // Area
                if (route.RouteValues.ContainsKey("area"))
                {
                    info.Area = route.RouteValues["area"];
                }

                // Path and Invocation of Razor Pages
                if (route is PageActionDescriptor)
                {
                    var e = route as PageActionDescriptor;
                    info.Path = e.ViewEnginePath;
                    info.Namespace = e.RelativePath;
                }

                // Path of Route Attribute
                if (route.AttributeRouteInfo != null)
                {
                    var e = route;
                    info.Path = $"/{e.AttributeRouteInfo.Template}";
                    AddParameters(info, e);
                }

                if (route is ControllerActionDescriptor)
                {
                    var e = route as ControllerActionDescriptor;
                    info.ControllerName = e.ControllerName;
                    info.ActionName = e.ActionName;

                    info.Namespace = e.ControllerTypeInfo.AsType().Namespace;
                    if (string.IsNullOrEmpty(e.AttributeRouteInfo?.Template))
                    {
                        if (!string.IsNullOrEmpty(info.Area))
                        {
                            info.Path = $"/{info.Area}";
                        }

                        info.Path += $"/{e.ControllerName}/{e.ActionName}";
                    }

                    AddParameters(info, e);
                }

                // Extract HTTP Verb
                if (route.ActionConstraints != null && route.ActionConstraints.Select(t => t.GetType()).Contains(typeof(HttpMethodActionConstraint)))
                {
                    if (route.ActionConstraints.FirstOrDefault(a => a.GetType() == typeof(HttpMethodActionConstraint)) is HttpMethodActionConstraint httpMethodAction)
                    {
                        info.HttpMethod = string.Join(",", httpMethodAction.HttpMethods);
                    }
                }

                // Exclude analyzer route
                if (info.Path != Router.DefaultRoute)
                {
                    list.Add(info);
                }
            }

            return list;
        }

        private void AddParameters(RouteInfo info, ActionDescriptor e)
        {
            foreach (var item in e.Parameters)
            {
                if (!info.Parameters.Any(o => o.Name == item.Name))
                {
                    info.Parameters.Add(new ParameterInfo
                    {
                        Name = item.Name,
                        Type = ConvertType(item.ParameterType.FullName),
                        BinderType = item.BindingInfo?.BinderType?.Name
                    });
                }
            }
        }

        private string ConvertType(string type)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                { typeof(object).FullName, "object" },
                { typeof(object[]).FullName, "object[]" },
                { typeof(int).FullName, "int" },
                { typeof(int[]).FullName, "int[]" },
                { typeof(int?).FullName, "int?" },
                { typeof(decimal).FullName, "decimal" },
                { typeof(decimal[]).FullName, "decimal[]" },
                { typeof(decimal?).FullName, "decimal?" },
                { typeof(byte).FullName, "byte" },
                { typeof(byte[]).FullName, "byte[]" },
                { typeof(byte?).FullName, "byte?" },
                { typeof(bool).FullName, "bool" },
                { typeof(bool[]).FullName, "bool[]" },
                { typeof(bool?).FullName, "bool?" },
                { typeof(string).FullName, "string" },
                { typeof(string[]).FullName, "string[]" },
                { typeof(DateTime).FullName, "DateTime" },
                { typeof(DateTime[]).FullName, "DateTime[]" },
                { typeof(DateTime?).FullName, "DateTime?" },
            };

            if (dictionary.ContainsKey(type))
            {
                return dictionary[type];
            }

            return type;
        }
    }
}
