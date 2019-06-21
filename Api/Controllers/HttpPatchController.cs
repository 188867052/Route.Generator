using System.Collections.Generic;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HttpPatchController : ControllerBase
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

        [HttpPatch("{key}")]
        public Dictionary<string, string> Patch_1_FromBody_1_Constraint(string key, [FromBody] string value)
        {
            return GetResponse(key, value, nameof(Patch_1_FromBody_1_Constraint));
        }

        [HttpPatch("{key}/{value}")]
        public Dictionary<string, string> Patch_2_Constraint(string key, string value)
        {
            return GetResponse(key, value, nameof(Patch_2_Constraint));
        }

        [HttpPatch]
        public Dictionary<string, string> Patch_1_FromBody([FromBody]string key)
        {
            return GetResponse(key, "", nameof(Patch_1_FromBody));
        }

        [HttpPatch]
        public JsonResult Patch_Model(PointModel point)
        {
            return new JsonResult(point);
        }
    }
}
