using System.Collections.Generic;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HttpPostController : ControllerBase
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

        [HttpPost("{key}")]
        public Dictionary<string, string> Post_1_FromBody_1_Constraint(string key, [FromBody] string value)
        {
            return GetResponse(key, value, nameof(Post_1_FromBody_1_Constraint));
        }

        [HttpPost("{key}/{value}")]
        public Dictionary<string, string> Post_2_Constraint(string key, string value)
        {
            return GetResponse(key, value, nameof(Post_2_Constraint));
        }

        [HttpPost]
        public Dictionary<string, string> Post_1_FromBody([FromBody]string key)
        {
            return GetResponse(key, "", nameof(Post_1_FromBody));
        }

        [HttpPost]
        public JsonResult Post_Model(PointModel point)
        {
            return new JsonResult(point);
        }
    }
}
