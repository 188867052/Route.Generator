using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Route.Generator.RouteAnalyzer;

namespace Api.Routes
{
    /// <summary>
    /// <see cref="Controllers.HttpDeleteController"/>
    /// </summary>
    public class HttpDeleteRoute
    {
        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete_1_Constraint_1_Parameter"/>
        /// </summary>
        public const string Delete_1_Constraint_1_Parameter = "/Delete_1_Constraint_1_Parameter/option/{key}";
        public static async Task<T> Delete_1_Constraint_1_ParameterAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "DELETE",
                Path = "/Delete_1_Constraint_1_Parameter/option/{key}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete_1_Constraint_1_Parameter_Desc"/>
        /// </summary>
        public const string Delete_1_Constraint_1_Parameter_Desc = "/Delete_1_Constraint_1_Parameter_Desc/{value}/{key}";
        public static async Task<T> Delete_1_Constraint_1_Parameter_DescAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "DELETE",
                Path = "/Delete_1_Constraint_1_Parameter_Desc/{value}/{key}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete4"/>
        /// </summary>
        public const string Delete4 = "/api/Values/option/{key}/{value?}";
        public static async Task<T> Delete4Async<T>(string key, string value)
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
        /// <see cref="Controllers.HttpDeleteController.Delete_2_Constraints_0_Parameter"/>
        /// </summary>
        public const string Delete_2_Constraints_0_Parameter = "/Delete_2_Constraints_0_Parameter/{key}/{value=test}";
        public static async Task<T> Delete_2_Constraints_0_ParameterAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "DELETE",
                Path = "/Delete_2_Constraints_0_Parameter/{key}/{value=test}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete_0_Constraint_0_Paramerter"/>
        /// </summary>
        public const string Delete_0_Constraint_0_Paramerter = "/api/HttpDelete/Delete_0_Constraint_0_Paramerter";
        public static async Task<T> Delete_0_Constraint_0_ParamerterAsync<T>()
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "DELETE",
                Path = "/api/HttpDelete/Delete_0_Constraint_0_Paramerter",
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete_0_Constraint_2_Paramerter"/>
        /// </summary>
        public const string Delete_0_Constraint_2_Paramerter = "/api/Values";
        public static async Task<T> Delete_0_Constraint_2_ParamerterAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "DELETE",
                Path = "/api/Values",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete_1_Nullable_Constraint"/>
        /// </summary>
        public const string Delete_1_Nullable_Constraint = "/api/HttpDelete/Delete_1_Nullable_Constraint/{id?}";
        public static async Task<T> Delete_1_Nullable_ConstraintAsync<T>(int? id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "DELETE",
                Path = "/api/HttpDelete/Delete_1_Nullable_Constraint/{id?}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int?"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete_1_Nullable_Parameter"/>
        /// </summary>
        public const string Delete_1_Nullable_Parameter = "/api/HttpDelete/Delete_1_Nullable_Parameter";
        public static async Task<T> Delete_1_Nullable_ParameterAsync<T>(int? id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "DELETE",
                Path = "/api/HttpDelete/Delete_1_Nullable_Parameter",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int?"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.DeleteName"/>
        /// </summary>
        public const string DeleteName = "/api/HttpDelete/DeleteName";
        public static async Task<T> DeleteNameAsync<T>(int id, string name)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "DELETE",
                Path = "/api/HttpDelete/DeleteName",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                    new ParameterInfo() {Name = "name", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, id, name);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Put"/>
        /// </summary>
        public const string Put = "/api/HttpDelete/Put/{id}";
        public static async Task<T> PutAsync<T>(int id, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "PUT",
                Path = "/api/HttpDelete/Put/{id}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, id, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete"/>
        /// </summary>
        public const string Delete = "/api/HttpDelete/Delete/{id}";
        public static async Task<T> DeleteAsync<T>(int id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "DELETE",
                Path = "/api/HttpDelete/Delete/{id}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.DeleteById"/>
        /// </summary>
        public const string DeleteById = "/api/Values/constraint/{id:range(1,10)}";
        public static async Task<T> DeleteByIdAsync<T>(int id)
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
        /// <see cref="Controllers.HttpDeleteController.Delete7"/>
        /// </summary>
        public const string Delete7 = "/api/Values/many/{isOk:bool}/{*DeleteDate:datetime}";
        public static async Task<T> Delete7Async<T>(bool isOk, DateTime? DeleteDate)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/api/Values/many/{isOk:bool}/{*DeleteDate:datetime}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "isOk", Type = "bool"},
                    new ParameterInfo() {Name = "DeleteDate", Type = "DateTime?"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, isOk, DeleteDate);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.DeletePostByEmail"/>
        /// </summary>
        public const string DeletePostByEmail = "/api/posts/{email:email}";
        public static async Task<T> DeletePostByEmailAsync<T>(string email)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "DELETE",
                Path = "/api/posts/{email:email}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "email", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, email);
        }
    }

    /// <summary>
    /// <see cref="Controllers.HttpGetController"/>
    /// </summary>
    public class HttpGetRoute
    {
        /// <summary>
        /// <see cref="Controllers.HttpGetController.Get_1_Constraint_1_Parameter"/>
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
        /// <see cref="Controllers.HttpGetController.Get_1_Constraint_1_Parameter_Desc"/>
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
        /// <see cref="Controllers.HttpGetController.Get4"/>
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
        /// <see cref="Controllers.HttpGetController.Get_2_Constraints_0_Parameter"/>
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
        /// <see cref="Controllers.HttpGetController.Get_0_Constraint_0_Paramerter"/>
        /// </summary>
        public const string Get_0_Constraint_0_Paramerter = "/api/HttpGet/Get_0_Constraint_0_Paramerter";
        public static async Task<T> Get_0_Constraint_0_ParamerterAsync<T>()
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/api/HttpGet/Get_0_Constraint_0_Paramerter",
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.Get_0_Constraint_2_Paramerter"/>
        /// </summary>
        public const string Get_0_Constraint_2_Paramerter = "/api/Values";
        public static async Task<T> Get_0_Constraint_2_ParamerterAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/api/Values",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.Get_1_Nullable_Constraint"/>
        /// </summary>
        public const string Get_1_Nullable_Constraint = "/api/HttpGet/Get_1_Nullable_Constraint/{id?}";
        public static async Task<T> Get_1_Nullable_ConstraintAsync<T>(int? id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/api/HttpGet/Get_1_Nullable_Constraint/{id?}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int?"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.Get_1_Nullable_Parameter"/>
        /// </summary>
        public const string Get_1_Nullable_Parameter = "/api/HttpGet/Get_1_Nullable_Parameter";
        public static async Task<T> Get_1_Nullable_ParameterAsync<T>(int? id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/api/HttpGet/Get_1_Nullable_Parameter",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int?"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.GetName"/>
        /// </summary>
        public const string GetName = "/api/HttpGet/GetName";
        public static async Task<T> GetNameAsync<T>(int id, string name)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "GET",
                Path = "/api/HttpGet/GetName",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                    new ParameterInfo() {Name = "name", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, id, name);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.Put"/>
        /// </summary>
        public const string Put = "/api/HttpGet/Put/{id}";
        public static async Task<T> PutAsync<T>(int id, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "PUT",
                Path = "/api/HttpGet/Put/{id}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, id, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.Delete"/>
        /// </summary>
        public const string Delete = "/api/HttpGet/Delete/{id}";
        public static async Task<T> DeleteAsync<T>(int id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "DELETE",
                Path = "/api/HttpGet/Delete/{id}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.GetById"/>
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
        /// <see cref="Controllers.HttpGetController.Get7"/>
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
        /// <see cref="Controllers.HttpGetController.GetPostByEmail"/>
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

    /// <summary>
    /// <see cref="Controllers.HttpPatchController"/>
    /// </summary>
    public class HttpPatchRoute
    {
        /// <summary>
        /// <see cref="Controllers.HttpPatchController.Patch_1_FromBody_1_Constraint"/>
        /// </summary>
        public const string Patch_1_FromBody_1_Constraint = "/api/HttpPatch/Patch_1_FromBody_1_Constraint/{key}";
        public static async Task<T> Patch_1_FromBody_1_ConstraintAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "PATCH",
                Path = "/api/HttpPatch/Patch_1_FromBody_1_Constraint/{key}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpPatchController.Patch_2_Constraint"/>
        /// </summary>
        public const string Patch_2_Constraint = "/api/HttpPatch/Patch_2_Constraint/{key}/{value}";
        public static async Task<T> Patch_2_ConstraintAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "PATCH",
                Path = "/api/HttpPatch/Patch_2_Constraint/{key}/{value}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpPatchController.Patch_1_FromBody"/>
        /// </summary>
        public const string Patch_1_FromBody = "/api/HttpPatch/Patch_1_FromBody";
        public static async Task<T> Patch_1_FromBodyAsync<T>(string key)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "PATCH",
                Path = "/api/HttpPatch/Patch_1_FromBody",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key);
        }

        /// <summary>
        /// <see cref="Controllers.HttpPatchController.Patch_Model"/>
        /// </summary>
        public const string Patch_Model = "/api/HttpPatch/Patch_Model";
        public static async Task<T> Patch_ModelAsync<T>(Api.Models.PointModel point)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "PATCH",
                Path = "/api/HttpPatch/Patch_Model",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "point", Type = "Api.Models.PointModel"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, point);
        }
    }

    /// <summary>
    /// <see cref="Controllers.HttpPostController"/>
    /// </summary>
    public class HttpPostRoute
    {
        /// <summary>
        /// <see cref="Controllers.HttpPostController.Post_1_FromBody_1_Constraint"/>
        /// </summary>
        public const string Post_1_FromBody_1_Constraint = "/api/HttpPost/Post_1_FromBody_1_Constraint/{key}";
        public static async Task<T> Post_1_FromBody_1_ConstraintAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "POST",
                Path = "/api/HttpPost/Post_1_FromBody_1_Constraint/{key}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpPostController.Post_2_Constraint"/>
        /// </summary>
        public const string Post_2_Constraint = "/api/HttpPost/Post_2_Constraint/{key}/{value}";
        public static async Task<T> Post_2_ConstraintAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "POST",
                Path = "/api/HttpPost/Post_2_Constraint/{key}/{value}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpPostController.Post_1_FromBody"/>
        /// </summary>
        public const string Post_1_FromBody = "/api/HttpPost/Post_1_FromBody";
        public static async Task<T> Post_1_FromBodyAsync<T>(string key)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "POST",
                Path = "/api/HttpPost/Post_1_FromBody",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key);
        }

        /// <summary>
        /// <see cref="Controllers.HttpPostController.Post_Model"/>
        /// </summary>
        public const string Post_Model = "/api/HttpPost/Post_Model";
        public static async Task<T> Post_ModelAsync<T>(Api.Models.PointModel point)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "POST",
                Path = "/api/HttpPost/Post_Model",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "point", Type = "Api.Models.PointModel"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, point);
        }
    }

    /// <summary>
    /// <see cref="Controllers.HttpPutController"/>
    /// </summary>
    public class HttpPutRoute
    {
        /// <summary>
        /// <see cref="Controllers.HttpPutController.Put_1_FromBody_1_Constraint"/>
        /// </summary>
        public const string Put_1_FromBody_1_Constraint = "/{key}";
        public static async Task<T> Put_1_FromBody_1_ConstraintAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "PUT",
                Path = "/{key}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpPutController.Put_2_Constraint"/>
        /// </summary>
        public const string Put_2_Constraint = "/{key}/{value}";
        public static async Task<T> Put_2_ConstraintAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "PUT",
                Path = "/{key}/{value}",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpPutController.Put_1_FromBody"/>
        /// </summary>
        public const string Put_1_FromBody = "/HttpPut/Put_1_FromBody";
        public static async Task<T> Put_1_FromBodyAsync<T>(string key)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "PUT",
                Path = "/HttpPut/Put_1_FromBody",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, key);
        }

        /// <summary>
        /// <see cref="Controllers.HttpPutController.Put_Model"/>
        /// </summary>
        public const string Put_Model = "/HttpPut/Put_Model";
        public static async Task<T> Put_ModelAsync<T>(Api.Models.PointModel point)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethod = "PUT",
                Path = "/HttpPut/Put_Model",
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "point", Type = "Api.Models.PointModel"},
                }
            };
            return await Core.Api.Framework.HttpClientAsync.Async<T>(routeInfo, point);
        }
    }
}
