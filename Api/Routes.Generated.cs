using System;
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
            {Api.Routes.ValuesRoute.Get4, new RouteInfo
                {
                    HttpMethod = "GET",
                    Parameters = new List<ParameterInfo>
                    {
                        new ParameterInfo() {Name = "key", Type = "string"},
                        new ParameterInfo() {Name = "value", Type = "string"},
                    }
                }
            },
            {Api.Routes.ValuesRoute.Get5, new RouteInfo
                {
                    HttpMethod = "GET",
                    Parameters = new List<ParameterInfo>
                    {
                        new ParameterInfo() {Name = "key", Type = "string"},
                        new ParameterInfo() {Name = "value", Type = "string"},
                    }
                }
            },
            {Api.Routes.ValuesRoute.Post2, new RouteInfo
                {
                    HttpMethod = "POST",
                    Parameters = new List<ParameterInfo>
                    {
                        new ParameterInfo() {Name = "valueTest", Type = "string"},
                    }
                }
            },
            {Api.Routes.ValuesRoute.GetById, new RouteInfo
                {
                    HttpMethod = "GET",
                    Parameters = new List<ParameterInfo>
                    {
                        new ParameterInfo() {Name = "id", Type = "int"},
                    }
                }
            },
            {Api.Routes.ValuesRoute.Get7, new RouteInfo
                {
                    HttpMethod = "GET",
                    Parameters = new List<ParameterInfo>
                    {
                        new ParameterInfo() {Name = "isOk", Type = "bool"},
                        new ParameterInfo() {Name = "getDate", Type = "DateTime?"},
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

        /// <summary>
        /// <see cref="Controllers.ValuesController.Get4"/>
        /// </summary>
        public const string Get4 = "/api/Values/api/Values/option/{key}/{value?}";
        public static async Task<T> Get4Async<T>(string key, string value)
        {
            return await Core.Api.Framework.HttpClientAsync.Async2<T>(Get4, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Get5"/>
        /// </summary>
        public const string Get5 = "/api/Values/api/Values/option/{key}/{value=test}";
        public static async Task<T> Get5Async<T>(string key, string value)
        {
            return await Core.Api.Framework.HttpClientAsync.Async2<T>(Get5, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Post2"/>
        /// </summary>
        public const string Post2 = "/api/Values";
        public static async Task<T> Post2Async<T>(string valueTest)
        {
            return await Core.Api.Framework.HttpClientAsync.Async2<T>(Post2, valueTest);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.GetById"/>
        /// </summary>
        public const string GetById = "/api/Values/api/Values/constraint/{id:range(1,10)}";
        public static async Task<T> GetByIdAsync<T>(int id)
        {
            return await Core.Api.Framework.HttpClientAsync.Async2<T>(GetById, id);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Get7"/>
        /// </summary>
        public const string Get7 = "/api/Values/api/Values/many/{isOk:bool}/{*getDate:datetime}";
        public static async Task<T> Get7Async<T>(bool isOk, DateTime? getDate)
        {
            return await Core.Api.Framework.HttpClientAsync.Async2<T>(Get7, isOk, getDate);
        }
    }
}
