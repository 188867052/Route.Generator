using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Route.Generator.RouteAnalyzer;

namespace Api.Routes
{
    /// <summary>
    /// <see cref="Controllers.ValuesController"/>
    /// </summary>
    public class ValuesRoute
    {
        /// <summary>
        /// <see cref="Controllers.ValuesController.Get_1_Constraint_1_Parameter"/>
        /// </summary>
        public const string Get_1_Constraint_1_Parameter = "/Get_1_Constraint_1_Parameter/option/{key}";
        public static async Task<T> Get_1_Constraint_1_ParameterAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/Get_1_Constraint_1_Parameter/option/{key}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Get_1_Constraint_1_Parameter_Desc"/>
        /// </summary>
        public const string Get_1_Constraint_1_Parameter_Desc = "/Get_1_Constraint_1_Parameter_Desc/{value}/{key}";
        public static async Task<T> Get_1_Constraint_1_Parameter_DescAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/Get_1_Constraint_1_Parameter_Desc/{value}/{key}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Get4"/>
        /// </summary>
        public const string Get4 = "/api/Values/option/{key}/{value?}";
        public static async Task<T> Get4Async<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/api/Values/option/{key}/{value?}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Get_2_Constraints_0_Parameter"/>
        /// </summary>
        public const string Get_2_Constraints_0_Parameter = "/Get_2_Constraints_0_Parameter/{key}/{value=test}";
        public static async Task<T> Get_2_Constraints_0_ParameterAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/Get_2_Constraints_0_Parameter/{key}/{value=test}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Get_0_Constraint_0_Paramerter"/>
        /// </summary>
        public const string Get_0_Constraint_0_Paramerter = "/api/Values/Get_0_Constraint_0_Paramerter";
        public static async Task<T> Get_0_Constraint_0_ParamerterAsync<T>()
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/api/Values/Get_0_Constraint_0_Paramerter",
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Get_0_Constraint_2_Paramerter"/>
        /// </summary>
        public const string Get_0_Constraint_2_Paramerter = "/api/Values/Get_0_Constraint_2_Paramerter";
        public static async Task<T> Get_0_Constraint_2_ParamerterAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/api/Values/Get_0_Constraint_2_Paramerter",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Get_1_Nullable_Constraint"/>
        /// </summary>
        public const string Get_1_Nullable_Constraint = "/api/Values/Get_1_Nullable_Constraint/{id?}";
        public static async Task<T> Get_1_Nullable_ConstraintAsync<T>(int? id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/api/Values/Get_1_Nullable_Constraint/{id?}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int?"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Get_1_Nullable_Parameter"/>
        /// </summary>
        public const string Get_1_Nullable_Parameter = "/api/Values/Get_1_Nullable_Parameter";
        public static async Task<T> Get_1_Nullable_ParameterAsync<T>(int? id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/api/Values/Get_1_Nullable_Parameter",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int?"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.GetName"/>
        /// </summary>
        public const string GetName = "/api/Values/GetName";
        public static async Task<T> GetNameAsync<T>(int id, string name)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/api/Values/GetName",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                    new ParameterInfo() {Name = "name", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, id, name);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Post"/>
        /// </summary>
        public const string Post = "/api/Values/Post";
        public static async Task<T> PostAsync<T>(string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "POST",
                Path = "/api/Values/Post",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, value);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Put"/>
        /// </summary>
        public const string Put = "/api/Values/Put/{id}";
        public static async Task<T> PutAsync<T>(int id, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "PUT",
                Path = "/api/Values/Put/{id}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, id, value);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Delete"/>
        /// </summary>
        public const string Delete = "/api/Values/Delete/{id}";
        public static async Task<T> DeleteAsync<T>(int id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "DELETE",
                Path = "/api/Values/Delete/{id}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Post2"/>
        /// </summary>
        public const string Post2 = "/api/Values/Post2";
        public static async Task<T> Post2Async<T>(string valueTest)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "POST",
                Path = "/api/Values/Post2",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "valueTest", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, valueTest);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.GetById"/>
        /// </summary>
        public const string GetById = "/api/Values/constraint/{id:range(1,10)}";
        public static async Task<T> GetByIdAsync<T>(int id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/api/Values/constraint/{id:range(1,10)}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.Get7"/>
        /// </summary>
        public const string Get7 = "/api/Values/many/{isOk:bool}/{*getDate:datetime}";
        public static async Task<T> Get7Async<T>(bool isOk, DateTime? getDate)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/api/Values/many/{isOk:bool}/{*getDate:datetime}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "isOk", Type = "bool"},
                    new ParameterInfo() {Name = "getDate", Type = "DateTime?"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, isOk, getDate);
        }

        /// <summary>
        /// <see cref="Controllers.ValuesController.GetPostByEmail"/>
        /// </summary>
        public const string GetPostByEmail = "/api/posts/{email:email}";
        public static async Task<T> GetPostByEmailAsync<T>(string email)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/api/posts/{email:email}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "email", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, email);
        }
    }
}
