﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HttpDeleteController  : ControllerBase
    {
        private Dictionary<string, string> DeleteResponse(string key, string value, string url)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "key", key },
                { "value", value },
                { "url", url}
            };

            return dictionary;
        }

        [HttpDelete]
        [Route("~/Delete_1_Constraint_1_Parameter/option/{key}")]
        public Dictionary<string, string> Delete_1_Constraint_1_Parameter(string key, string value)
        {
            return DeleteResponse(key, value, nameof(Delete_1_Constraint_1_Parameter));
        }

        [HttpDelete]
        [Route("~/Delete_1_Constraint_1_Parameter_Desc/{value}/{key}")]
        public Dictionary<string, string> Delete_1_Constraint_1_Parameter_Desc(string key, string value)
        {
            return DeleteResponse(key, value, nameof(Delete_1_Constraint_1_Parameter_Desc));
        }

        [Route("~/api/Values/option/{key}/{value?}")]
        public Dictionary<string, string> Delete4(string key, string value = "test")
        {
            return DeleteResponse(key, value, nameof(Delete4));
        }

        [HttpDelete]
        [Route("~/Delete_2_Constraints_0_Parameter/{key}/{value=test}")]
        public Dictionary<string, string> Delete_2_Constraints_0_Parameter(string key, string value)
        {
            return DeleteResponse(key, value, nameof(Delete_2_Constraints_0_Parameter));
        }

        [HttpDelete]
        public ActionResult<IEnumerable<string>> Delete_0_Constraint_0_Paramerter()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpDelete]
        [Route("~/api/Values")]
        public Dictionary<string, string> Delete_0_Constraint_2_Paramerter(string key, string value)
        {
            return DeleteResponse(key, value, nameof(Delete_0_Constraint_2_Paramerter));
        }

        [HttpDelete("{id?}")]
        public Dictionary<string, string> Delete_1_Nullable_Constraint(int? id)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "id", id.HasValue?id.ToString():null },
                { "url",  nameof(Delete_1_Nullable_Constraint)}
            };

            return dictionary;
        }

        [HttpDelete]
        public Dictionary<string, string> Delete_1_Nullable_Parameter(int? id)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "id", id.HasValue?id.ToString():null },
                { "url",  nameof(Delete_1_Nullable_Constraint)}
            };

            return dictionary;
        }

        [HttpDelete]
        public ActionResult<string> DeleteName(int id, string name)
        {
            return "name";
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }



        [Route("~/api/Values/constraint/{id:range(1,10)}")]
        public string DeleteById(int id)
        {
            return "value:" + id.ToString();
        }

        [Route("~/api/Values/many/{isOk:bool}/{*DeleteDate:datetime}")]
        public IActionResult Delete7(bool isOk, DateTime? DeleteDate = null)
        {
            return null;
        }

        [HttpDelete]
        [Route("~/api/posts/{email:email}")]
        public IActionResult DeletePostByEmail(string email)
        {
            return Content("Coming from DeletePostByEmail");
        }
    }
}
