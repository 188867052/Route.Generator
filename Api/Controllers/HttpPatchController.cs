namespace Api.Controllers
{
    using System.Collections.Generic;
    using Api.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HttpPatchController : StandardController
    {
        [HttpPatch("{key}")]
        public Dictionary<string, string> Patch_1_FromBody_1_Constraint(string key, [FromBody] string value)
        {
            return this.ResponseDictionary(key, value, nameof(this.Patch_1_FromBody_1_Constraint));
        }

        [HttpPatch("{key}/{value}")]
        public Dictionary<string, string> Patch_2_Constraint(string key, string value)
        {
            return this.ResponseDictionary(key, value, nameof(this.Patch_2_Constraint));
        }

        [HttpPatch]
        public Dictionary<string, string> Patch_1_FromBody([FromBody]string key)
        {
            return this.ResponseDictionary(key, string.Empty, nameof(this.Patch_1_FromBody));
        }

        [HttpPatch]
        public JsonResult Patch_Model(PointModel point)
        {
            return new JsonResult(point);
        }
    }
}
