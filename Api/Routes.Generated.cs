using System.Collections.Generic;
using System.Threading.Tasks;
using Route.Generator.RouteAnalyzer;

namespace Api.Routes
{
    public class Cache
    {
        public static Dictionary<string, RouteInfo> Dictionary = new Dictionary<string, RouteInfo>()
        {
            {Api.Routes.ValuesRoute.Get, new RouteInfo
                {
                    HttpMethod = "GET",
                }
            },
            {Api.Routes.ValuesRoute.Get1, new RouteInfo
                {
                    HttpMethod = "GET",
                    Parameters = new List<ParameterInfo>
                    {
                        new ParameterInfo() {Name = "id", Type = "int"},
                    }
                }
            },
            {Api.Routes.ValuesRoute.Get2, new RouteInfo
                {
                    HttpMethod = "GET",
                    Parameters = new List<ParameterInfo>
                    {
                        new ParameterInfo() {Name = "id", Type = "int"},
                        new ParameterInfo() {Name = "name", Type = "string"},
                    }
                }
            },
            {Api.Routes.ValuesRoute.Post, new RouteInfo
                {
                    HttpMethod = "POST",
                    Parameters = new List<ParameterInfo>
                    {
                        new ParameterInfo() {Name = "value", Type = "string"},
                    }
                }
            },
            {Api.Routes.ValuesRoute.Put, new RouteInfo
                {
                    HttpMethod = "PUT",
                    Parameters = new List<ParameterInfo>
                    {
                        new ParameterInfo() {Name = "id", Type = "int"},
                        new ParameterInfo() {Name = "value", Type = "string"},
                    }
                }
            },
            {Api.Routes.ValuesRoute.Delete, new RouteInfo
                {
                    HttpMethod = "DELETE",
                    Parameters = new List<ParameterInfo>
                    {
                        new ParameterInfo() {Name = "id", Type = "int"},
                    }
                }
            },
        };
    }

    /// <summary>
    /// <see cref="Controllers.ValuesController"/>
    /// </summary>
    public class ValuesRoute
    {
        /// <summary>
        /// <see cref="Controllers.ValuesController.Get"/>
        /// </summary>
        public const string Get = "/api/Values";
        public static async Task<T> GetAsync<T>()
        {
            return await Core.Api.Framework.HttpClientAsync.Async2<T>(Get);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Get"/>
        /// </summary>
        public const string Get1 = "/api/Values/{id}";
        public static async Task<T> GetAsync<T>(int id)
        {
            return await Core.Api.Framework.HttpClientAsync.Async2<T>(Get1, id);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Get"/>
        /// </summary>
        public const string Get2 = "/api/Values";
        public static async Task<T> GetAsync<T>(int id, string name)
        {
            return await Core.Api.Framework.HttpClientAsync.Async2<T>(Get2, id, name);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Post"/>
        /// </summary>
        public const string Post = "/api/Values";
        public static async Task<T> PostAsync<T>(string value)
        {
            return await Core.Api.Framework.HttpClientAsync.Async2<T>(Post, value);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Put"/>
        /// </summary>
        public const string Put = "/api/Values/{id}";
        public static async Task<T> PutAsync<T>(int id, string value)
        {
            return await Core.Api.Framework.HttpClientAsync.Async2<T>(Put, id, value);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Delete"/>
        /// </summary>
        public const string Delete = "/api/Values/{id}";
        public static async Task<T> DeleteAsync<T>(int id)
        {
            return await Core.Api.Framework.HttpClientAsync.Async2<T>(Delete, id);
        }
    }
}
