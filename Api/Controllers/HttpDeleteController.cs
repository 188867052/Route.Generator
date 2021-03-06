﻿namespace Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HttpDeleteController : StandardController
    {
        [HttpDelete]
        [Route("~/Delete_5_Constraint_5_Parameter_None_Order/{constraint2}/{constraint1}/{constraint3}/{constraint5}/{constraint4}")]
        public Dictionary<string, string> Delete_5_Constraint_5_Parameter_None_Order(
          string constraint4,
          string parameter5,
          string parameter3,
          string constraint1,
          string constraint5,
          string constraint2,
          string parameter1,
          string parameter2,
          string constraint3,
          string parameter4)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "parameter1", parameter1 },
                { "parameter2", parameter2 },
                { "parameter3", parameter3 },
                { "parameter4", parameter4 },
                { "parameter5", parameter5 },
                { "constraint1", constraint1 },
                { "constraint2", constraint2 },
                { "constraint3", constraint3 },
                { "constraint4", constraint4 },
                { "constraint5", constraint5 },
                { "url", nameof(this.Delete_5_Constraint_5_Parameter_None_Order) },
            };
            return dictionary;
        }

        [HttpDelete]
        [Route("~/Delete_1_Constraint_1_Parameter/option/{key}")]
        public Dictionary<string, string> Delete_1_Constraint_1_Parameter(string key, string value)
        {
            return this.ResponseDictionary(key, value, nameof(this.Delete_1_Constraint_1_Parameter));
        }

        [HttpDelete]
        [Route("~/Delete_1_Constraint_1_Parameter_Desc/{value}/{key}")]
        public Dictionary<string, string> Delete_1_Constraint_1_Parameter_Desc(string key, string value)
        {
            return this.ResponseDictionary(key, value, nameof(this.Delete_1_Constraint_1_Parameter_Desc));
        }

        [Route("~/api/Values/option/{key}/{value?}")]
        public Dictionary<string, string> Delete4(string key, string value = "test")
        {
            return this.ResponseDictionary(key, value, nameof(this.Delete4));
        }

        [HttpDelete]
        [Route("~/Delete_2_Constraints_0_Parameter/{key}/{value=test}")]
        public Dictionary<string, string> Delete_2_Constraints_0_Parameter(string key, string value)
        {
            return this.ResponseDictionary(key, value, nameof(this.Delete_2_Constraints_0_Parameter));
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
            return this.ResponseDictionary(key, value, nameof(this.Delete_0_Constraint_2_Paramerter));
        }

        [HttpDelete("{id?}")]
        public Dictionary<string, string> Delete_1_Nullable_Constraint(int? id)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "id", id.HasValue ? id.ToString() : null },
                { "url",  nameof(this.Delete_1_Nullable_Constraint) },
            };

            return dictionary;
        }

        [HttpDelete]
        public Dictionary<string, string> Delete_1_Nullable_Parameter(int? id)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "id", id.HasValue ? id.ToString() : null },
                { "url",  nameof(this.Delete_1_Nullable_Constraint) },
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
        public IActionResult Delete7(bool isOk, DateTime? deleteDate = null)
        {
            return null;
        }
    }
}
