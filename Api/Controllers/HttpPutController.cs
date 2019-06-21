using System.Collections.Generic;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class HttpPutController : ControllerBase
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

        [HttpPut("{key}")]
        public Dictionary<string, string> Put_1_FromBody_1_Constraint(string key, [FromBody] string value)
        {
            return GetResponse(key, value, nameof(Put_1_FromBody_1_Constraint));
        }

        [HttpPut("{key}/{value}")]
        public Dictionary<string, string> Put_2_Constraint(string key, string value)
        {
            return GetResponse(key, value, nameof(Put_2_Constraint));
        }

        [HttpPut]
        public Dictionary<string, string> Put_1_FromBody([FromBody]string key)
        {
            return GetResponse(key, "", nameof(Put_1_FromBody));
        }

        [HttpPut]
        public JsonResult Put_Model(PointModel point)
        {
            return new JsonResult(point);
        }
    }
}
