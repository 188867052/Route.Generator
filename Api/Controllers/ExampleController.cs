namespace Api.Controllers
{
    using System.Collections.Generic;
    using Api.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExampleController : StandardController
    {
        [HttpGet("{key}")]
        public Dictionary<string, string> GetValues(string key, string value)
        {
            return this.ResponseDictionary(key, value, nameof(this.GetValues));
        }

        [HttpPost]
        public Dictionary<string, string> Edit(PointModel model)
        {
            return this.ResponseDictionary(null, null, nameof(this.Edit));
        }

        [HttpDelete]
        public Dictionary<string, string> Delete(string id)
        {
            return this.ResponseDictionary(null, null, nameof(this.Delete));
        }

        [HttpDelete]
        public Dictionary<string, string> Just_for_test(string id)
        {
            return this.ResponseDictionary(null, null, nameof(this.Delete));
        }

        [HttpDelete]
        public Dictionary<string, string> Just_for_test2(int? id, string name)
        {
            return this.ResponseDictionary(null, null, nameof(this.Delete));
        }
    }
}
