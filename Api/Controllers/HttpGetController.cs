namespace Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HttpGetController : StandardController
    {
        [HttpGet]
        [Route("~/Get_1_Constraint_1_Parameter/option/{key}")]
        public Dictionary<string, string> Get_1_Constraint_1_Parameter(string key, string value)
        {
            return this.ResponseDictionary(key, value, nameof(this.Get_1_Constraint_1_Parameter));
        }

        [HttpGet]
        [Route("~/Get_5_Constraint_5_Parameter_None_Order/{constraint2}/{constraint1}/{constraint3}/{constraint5}/{constraint4}")]
        public Dictionary<string, string> Get_5_Constraint_5_Parameter_None_Order(
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
                { "url", nameof(this.Get_5_Constraint_5_Parameter_None_Order) },
            };
            return dictionary;
        }

        [HttpGet]
        [Route("~/Get_1_Constraint_1_Parameter_Desc/{value}/{key}")]
        public Dictionary<string, string> Get_1_Constraint_1_Parameter_Desc(string key, string value)
        {
            return this.ResponseDictionary(key, value, nameof(this.Get_1_Constraint_1_Parameter_Desc));
        }

        [Route("~/api/Values/option/{key}/{value?}")]
        public Dictionary<string, string> Get4(string key, string value = "test")
        {
            return this.ResponseDictionary(key, value, nameof(this.Get4));
        }

        [HttpGet]
        [Route("~/Get_2_Constraints_0_Parameter/{key}/{value=test}")]
        public Dictionary<string, string> Get_2_Constraints_0_Parameter(string key, string value)
        {
            return this.ResponseDictionary(key, value, nameof(this.Get_2_Constraints_0_Parameter));
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get_0_Constraint_0_Paramerter()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("~/api/Values")]
        public Dictionary<string, string> Get_0_Constraint_2_Paramerter(string key, string value)
        {
            return this.ResponseDictionary(key, value, nameof(this.Get_0_Constraint_2_Paramerter));
        }

        [HttpGet("{id?}")]
        public Dictionary<string, string> Get_1_Nullable_Constraint(int? id)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "id", id.HasValue ? id.ToString() : null },
                { "url",  nameof(this.Get_1_Nullable_Constraint) },
            };

            return dictionary;
        }

        [HttpGet]
        public Dictionary<string, string> Get_1_Nullable_Parameter(int? id)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "id", id.HasValue ? id.ToString() : null },
                { "url",  nameof(this.Get_1_Nullable_Constraint) },
            };

            return dictionary;
        }

        [HttpGet]
        public ActionResult<string> GetName(int id, string name)
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
        public string GetById(int id)
        {
            return "value:" + id.ToString();
        }

        [Route("~/api/Values/many/{isOk:bool}/{*getDate:datetime}")]
        public IActionResult Get7(bool isOk, DateTime? getDate = null)
        {
            return null;
        }

        [HttpGet]
        [Route("~/api/posts/{email:email}")]
        public IActionResult GetPostByEmail(string email)
        {
            return this.Content("Coming from GetPostByEmail");
        }
    }
}
