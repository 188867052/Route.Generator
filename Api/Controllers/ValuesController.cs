using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private Dictionary<string, string> GetResponse(string key, string value, string url)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "key", key },
                { "value", value },
                { "url", url}
            };

            return dictionary;
        }

        [HttpGet]
        [Route("~/Get_1_Constraint_1_Parameter/option/{key}")]
        public Dictionary<string, string> Get_1_Constraint_1_Parameter(string key, string value)
        {
            return GetResponse(key, value, nameof(Get_1_Constraint_1_Parameter));
        }

        [HttpGet]
        [Route("~/Get_1_Constraint_1_Parameter_Desc/{value}/{key}")]
        public Dictionary<string, string> Get_1_Constraint_1_Parameter_Desc(string key, string value)
        {
            return GetResponse(key, value, nameof(Get_1_Constraint_1_Parameter_Desc));
        }

        [Route("~/api/Values/option/{key}/{value?}")]
        public Dictionary<string, string> Get4(string key, string value = "test")
        {
            return GetResponse(key, value, nameof(Get4));
        }

        [HttpGet]
        [Route("~/Get_2_Constraints_0_Parameter/{key}/{value=test}")]
        public Dictionary<string, string> Get_2_Constraints_0_Parameter(string key, string value)
        {
            return GetResponse(key, value, nameof(Get_2_Constraints_0_Parameter));
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get_0_Constraint_0_Paramerter()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public Dictionary<string, string> Get_0_Constraint_2_Paramerter(string key, string value)
        {
            return GetResponse(key, value, nameof(Get_0_Constraint_2_Paramerter));
        }

        [HttpGet("{id?}")]
        public Dictionary<string, string> Get_1_Nullable_Constraint(int? id)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "id", id.HasValue?id.ToString():null },
                { "url",  nameof(Get_1_Nullable_Constraint)}
            };

            return dictionary;
        }

        [HttpGet]
        public Dictionary<string, string> Get_1_Nullable_Parameter(int? id)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "id", id.HasValue?id.ToString():null },
                { "url",  nameof(Get_1_Nullable_Constraint)}
            };

            return dictionary;
        }

        [HttpGet]
        public ActionResult<string> GetName(int id, string name)
        {
            return "name";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        public ActionResult<string> Post2([FromBody]string valueTest)
        {
            return valueTest;
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
            return Content("Coming from GetPostByEmail");
        }
    }
}
