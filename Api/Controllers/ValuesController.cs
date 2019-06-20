using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // GET api/values/5
        [HttpGet]
        public ActionResult<string> Get(int id, string name)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("api/Values/option/{key}/{value?}")]
        public Dictionary<string, string> Get4(string key, string value = "test")
        {
            return new Dictionary<string, string>()
            {
                {key,value}
            };
        }

        [Route("api/Values/option/{key}/{value=test}")]
        public Dictionary<string, string> Get5(string key, string value)
        {
            return new Dictionary<string, string>()
            {
                {key,value}
            };
        }

        [HttpPost]
        public ActionResult<string> Post2([FromBody]string valueTest)
        {
            return valueTest;
        }

        [Route("api/Values/constraint/{id:range(1,10)}")]
        public string GetById(int id)
        {
            return "value:" + id.ToString();
        }

        [Route("api/Values/many/{isOk:bool}/{*getDate:datetime}")]
        public IActionResult Get7(bool isOk, DateTime? getDate = null)
        {
            return null;
        }
    }
}
