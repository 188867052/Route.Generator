namespace Api.Controllers
{
    using System.Collections.Generic;
    using Api.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HttpPostController : StandardController
    {
        [HttpPost("{key}")]
        public Dictionary<string, string> Post_1_FromBody_1_Constraint(string key, [FromBody] string value)
        {
            return this.ResponseDictionary(key, value, nameof(this.Post_1_FromBody_1_Constraint));
        }

        [HttpPost("{key}/{value}")]
        public Dictionary<string, string> Post_2_Constraint(string key, string value)
        {
            return this.ResponseDictionary(key, value, nameof(this.Post_2_Constraint));
        }

        [HttpPost]
        public Dictionary<string, string> Post_1_FromBody([FromBody]string key)
        {
            return this.ResponseDictionary(key, string.Empty, nameof(this.Post_1_FromBody));
        }

        [HttpPost]
        public JsonResult Post_Model(PointModel point)
        {
            return new JsonResult(point);
        }
    }
}
