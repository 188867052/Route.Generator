using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Route.Generator;
using Route.Generator.RouteAnalyzer;

namespace Api.Routes
{
    /// <summary>
    /// <see cref="Controllers.HttpDeleteController"/>
    /// </summary>
    public class HttpDeleteRoute
    {
        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete_5_Constraint_5_Parameter_None_Order"/>
        /// </summary>
        public const string Delete_5_Constraint_5_Parameter_None_Order = "/Delete_5_Constraint_5_Parameter_None_Order/{constraint2}/{constraint1}/{constraint3}/{constraint5}/{constraint4}";
        public static async Task<T> Delete_5_Constraint_5_Parameter_None_OrderAsync<T>(string constraint4, string parameter5, string parameter3, string constraint1, string constraint5, string constraint2, string parameter1, string parameter2, string constraint3, string parameter4)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "DELETE",
                Path = Delete_5_Constraint_5_Parameter_None_Order,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "constraint4", Type = "string"},
                    new ParameterInfo() {Name = "parameter5", Type = "string"},
                    new ParameterInfo() {Name = "parameter3", Type = "string"},
                    new ParameterInfo() {Name = "constraint1", Type = "string"},
                    new ParameterInfo() {Name = "constraint5", Type = "string"},
                    new ParameterInfo() {Name = "constraint2", Type = "string"},
                    new ParameterInfo() {Name = "parameter1", Type = "string"},
                    new ParameterInfo() {Name = "parameter2", Type = "string"},
                    new ParameterInfo() {Name = "constraint3", Type = "string"},
                    new ParameterInfo() {Name = "parameter4", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, constraint4, parameter5, parameter3, constraint1, constraint5, constraint2, parameter1, parameter2, constraint3, parameter4);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete_1_Constraint_1_Parameter"/>
        /// </summary>
        public const string Delete_1_Constraint_1_Parameter = "/Delete_1_Constraint_1_Parameter/option/{key}";
        public static async Task<T> Delete_1_Constraint_1_ParameterAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "DELETE",
                Path = Delete_1_Constraint_1_Parameter,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete_1_Constraint_1_Parameter_Desc"/>
        /// </summary>
        public const string Delete_1_Constraint_1_Parameter_Desc = "/Delete_1_Constraint_1_Parameter_Desc/{value}/{key}";
        public static async Task<T> Delete_1_Constraint_1_Parameter_DescAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "DELETE",
                Path = Delete_1_Constraint_1_Parameter_Desc,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete4"/>
        /// </summary>
        public const string Delete4 = "/api/Values/option/{key}/{value?}";
        public static async Task<T> Delete4Async<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "GET",
                Path = Delete4,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete_2_Constraints_0_Parameter"/>
        /// </summary>
        public const string Delete_2_Constraints_0_Parameter = "/Delete_2_Constraints_0_Parameter/{key}/{value=test}";
        public static async Task<T> Delete_2_Constraints_0_ParameterAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "DELETE",
                Path = Delete_2_Constraints_0_Parameter,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete_0_Constraint_0_Paramerter"/>
        /// </summary>
        public const string Delete_0_Constraint_0_Paramerter = "/api/HttpDelete/Delete_0_Constraint_0_Paramerter";
        public static async Task<T> Delete_0_Constraint_0_ParamerterAsync<T>()
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "DELETE",
                Path = Delete_0_Constraint_0_Paramerter,
            };
            return await HttpClientAsync.Async<T>(routeInfo);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete_0_Constraint_2_Paramerter"/>
        /// </summary>
        public const string Delete_0_Constraint_2_Paramerter = "/api/Values";
        public static async Task<T> Delete_0_Constraint_2_ParamerterAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "DELETE",
                Path = Delete_0_Constraint_2_Paramerter,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete_1_Nullable_Constraint"/>
        /// </summary>
        public const string Delete_1_Nullable_Constraint = "/api/HttpDelete/Delete_1_Nullable_Constraint/{id?}";
        public static async Task<T> Delete_1_Nullable_ConstraintAsync<T>(int? id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "DELETE",
                Path = Delete_1_Nullable_Constraint,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int?"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete_1_Nullable_Parameter"/>
        /// </summary>
        public const string Delete_1_Nullable_Parameter = "/api/HttpDelete/Delete_1_Nullable_Parameter";
        public static async Task<T> Delete_1_Nullable_ParameterAsync<T>(int? id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "DELETE",
                Path = Delete_1_Nullable_Parameter,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int?"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.DeleteName"/>
        /// </summary>
        public const string DeleteName = "/api/HttpDelete/DeleteName";
        public static async Task<T> DeleteNameAsync<T>(int id, string name)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "DELETE",
                Path = DeleteName,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                    new ParameterInfo() {Name = "name", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, id, name);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Put"/>
        /// </summary>
        public const string Put = "/api/HttpDelete/Put/{id}";
        public static async Task<T> PutAsync<T>(int id, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "PUT",
                Path = Put,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, id, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete"/>
        /// </summary>
        public const string Delete = "/api/HttpDelete/Delete/{id}";
        public static async Task<T> DeleteAsync<T>(int id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "DELETE",
                Path = Delete,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.DeleteById"/>
        /// </summary>
        public const string DeleteById = "/api/Values/constraint/{id:range(1,10)}";
        public static async Task<T> DeleteByIdAsync<T>(int id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "GET",
                Path = DeleteById,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.Delete7"/>
        /// </summary>
        public const string Delete7 = "/api/Values/many/{isOk:bool}/{*DeleteDate:datetime}";
        public static async Task<T> Delete7Async<T>(bool isOk, DateTime? deleteDate)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "GET",
                Path = Delete7,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "isOk", Type = "bool"},
                    new ParameterInfo() {Name = "deleteDate", Type = "DateTime?"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, isOk, deleteDate);
        }

        /// <summary>
        /// <see cref="Controllers.HttpDeleteController.DeletePostByEmail"/>
        /// </summary>
        public const string DeletePostByEmail = "/api/posts/{email:email}";
        public static async Task<T> DeletePostByEmailAsync<T>(string email)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "DELETE",
                Path = DeletePostByEmail,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "email", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, email);
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
                HttpMethods = "GET",
                Path = Get_1_Constraint_1_Parameter,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.Get_5_Constraint_5_Parameter_None_Order"/>
        /// </summary>
        public const string Get_5_Constraint_5_Parameter_None_Order = "/Get_5_Constraint_5_Parameter_None_Order/{constraint2}/{constraint1}/{constraint3}/{constraint5}/{constraint4}";
        public static async Task<T> Get_5_Constraint_5_Parameter_None_OrderAsync<T>(string constraint4, string parameter5, string parameter3, string constraint1, string constraint5, string constraint2, string parameter1, string parameter2, string constraint3, string parameter4)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "GET",
                Path = Get_5_Constraint_5_Parameter_None_Order,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "constraint4", Type = "string"},
                    new ParameterInfo() {Name = "parameter5", Type = "string"},
                    new ParameterInfo() {Name = "parameter3", Type = "string"},
                    new ParameterInfo() {Name = "constraint1", Type = "string"},
                    new ParameterInfo() {Name = "constraint5", Type = "string"},
                    new ParameterInfo() {Name = "constraint2", Type = "string"},
                    new ParameterInfo() {Name = "parameter1", Type = "string"},
                    new ParameterInfo() {Name = "parameter2", Type = "string"},
                    new ParameterInfo() {Name = "constraint3", Type = "string"},
                    new ParameterInfo() {Name = "parameter4", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, constraint4, parameter5, parameter3, constraint1, constraint5, constraint2, parameter1, parameter2, constraint3, parameter4);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.Get_1_Constraint_1_Parameter_Desc"/>
        /// </summary>
        public const string Get_1_Constraint_1_Parameter_Desc = "/Get_1_Constraint_1_Parameter_Desc/{value}/{key}";
        public static async Task<T> Get_1_Constraint_1_Parameter_DescAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "GET",
                Path = Get_1_Constraint_1_Parameter_Desc,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.Get4"/>
        /// </summary>
        public const string Get4 = "/api/Values/option/{key}/{value?}";
        public static async Task<T> Get4Async<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "GET",
                Path = Get4,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.Get_2_Constraints_0_Parameter"/>
        /// </summary>
        public const string Get_2_Constraints_0_Parameter = "/Get_2_Constraints_0_Parameter/{key}/{value=test}";
        public static async Task<T> Get_2_Constraints_0_ParameterAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "GET",
                Path = Get_2_Constraints_0_Parameter,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.Get_0_Constraint_0_Paramerter"/>
        /// </summary>
        public const string Get_0_Constraint_0_Paramerter = "/api/HttpGet/Get_0_Constraint_0_Paramerter";
        public static async Task<T> Get_0_Constraint_0_ParamerterAsync<T>()
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "GET",
                Path = Get_0_Constraint_0_Paramerter,
            };
            return await HttpClientAsync.Async<T>(routeInfo);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.Get_0_Constraint_2_Paramerter"/>
        /// </summary>
        public const string Get_0_Constraint_2_Paramerter = "/api/Values";
        public static async Task<T> Get_0_Constraint_2_ParamerterAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "GET",
                Path = Get_0_Constraint_2_Paramerter,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.Get_1_Nullable_Constraint"/>
        /// </summary>
        public const string Get_1_Nullable_Constraint = "/api/HttpGet/Get_1_Nullable_Constraint/{id?}";
        public static async Task<T> Get_1_Nullable_ConstraintAsync<T>(int? id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "GET",
                Path = Get_1_Nullable_Constraint,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int?"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.Get_1_Nullable_Parameter"/>
        /// </summary>
        public const string Get_1_Nullable_Parameter = "/api/HttpGet/Get_1_Nullable_Parameter";
        public static async Task<T> Get_1_Nullable_ParameterAsync<T>(int? id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "GET",
                Path = Get_1_Nullable_Parameter,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int?"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.GetName"/>
        /// </summary>
        public const string GetName = "/api/HttpGet/GetName";
        public static async Task<T> GetNameAsync<T>(int id, string name)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "GET",
                Path = GetName,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                    new ParameterInfo() {Name = "name", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, id, name);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.Put"/>
        /// </summary>
        public const string Put = "/api/HttpGet/Put/{id}";
        public static async Task<T> PutAsync<T>(int id, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "PUT",
                Path = Put,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, id, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.Delete"/>
        /// </summary>
        public const string Delete = "/api/HttpGet/Delete/{id}";
        public static async Task<T> DeleteAsync<T>(int id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "DELETE",
                Path = Delete,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.GetById"/>
        /// </summary>
        public const string GetById = "/api/Values/constraint/{id:range(1,10)}";
        public static async Task<T> GetByIdAsync<T>(int id)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "GET",
                Path = GetById,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "id", Type = "int"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, id);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.Get7"/>
        /// </summary>
        public const string Get7 = "/api/Values/many/{isOk:bool}/{*getDate:datetime}";
        public static async Task<T> Get7Async<T>(bool isOk, DateTime? getDate)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "GET",
                Path = Get7,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "isOk", Type = "bool"},
                    new ParameterInfo() {Name = "getDate", Type = "DateTime?"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, isOk, getDate);
        }

        /// <summary>
        /// <see cref="Controllers.HttpGetController.GetPostByEmail"/>
        /// </summary>
        public const string GetPostByEmail = "/api/posts/{email:email}";
        public static async Task<T> GetPostByEmailAsync<T>(string email)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "GET",
                Path = GetPostByEmail,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "email", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, email);
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
                HttpMethods = "PATCH",
                Path = Patch_1_FromBody_1_Constraint,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpPatchController.Patch_2_Constraint"/>
        /// </summary>
        public const string Patch_2_Constraint = "/api/HttpPatch/Patch_2_Constraint/{key}/{value}";
        public static async Task<T> Patch_2_ConstraintAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "PATCH",
                Path = Patch_2_Constraint,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpPatchController.Patch_1_FromBody"/>
        /// </summary>
        public const string Patch_1_FromBody = "/api/HttpPatch/Patch_1_FromBody";
        public static async Task<T> Patch_1_FromBodyAsync<T>(string key)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "PATCH",
                Path = Patch_1_FromBody,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key);
        }

        /// <summary>
        /// <see cref="Controllers.HttpPatchController.Patch_Model"/>
        /// </summary>
        public const string Patch_Model = "/api/HttpPatch/Patch_Model";
        public static async Task<T> Patch_ModelAsync<T>(Api.Models.PointModel point)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "PATCH",
                Path = Patch_Model,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "point", Type = "Api.Models.PointModel"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, point);
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
                HttpMethods = "POST",
                Path = Post_1_FromBody_1_Constraint,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpPostController.Post_2_Constraint"/>
        /// </summary>
        public const string Post_2_Constraint = "/api/HttpPost/Post_2_Constraint/{key}/{value}";
        public static async Task<T> Post_2_ConstraintAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "POST",
                Path = Post_2_Constraint,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpPostController.Post_1_FromBody"/>
        /// </summary>
        public const string Post_1_FromBody = "/api/HttpPost/Post_1_FromBody";
        public static async Task<T> Post_1_FromBodyAsync<T>(string key)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "POST",
                Path = Post_1_FromBody,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key);
        }

        /// <summary>
        /// <see cref="Controllers.HttpPostController.Post_Model"/>
        /// </summary>
        public const string Post_Model = "/api/HttpPost/Post_Model";
        public static async Task<T> Post_ModelAsync<T>(Api.Models.PointModel point)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "POST",
                Path = Post_Model,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "point", Type = "Api.Models.PointModel"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, point);
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
                HttpMethods = "PUT",
                Path = Put_1_FromBody_1_Constraint,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key, value);
        }

        /// <summary>
        /// <see cref="Controllers.HttpPutController.Put_2_Constraint"/>
        /// </summary>
        public const string Put_2_Constraint = "/{key}/{value}";
        public static async Task<T> Put_2_ConstraintAsync<T>(string key, string value)
        {
            var routeInfo = new RouteInfo
            {
                HttpMethods = "PUT",
                Path = Put_2_Constraint,
                Parameters = new List<ParameterInfo>
                {
                    new ParameterInfo() {Name = "key", Type = "string"},
                    new ParameterInfo() {Name = "value", Type = "string"},
                }
            };
            return await HttpClientAsync.Async<T>(routeInfo, key, value);
        }
    }
}
