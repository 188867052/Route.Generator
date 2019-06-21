namespace Api.Controllers
{
    using System.Collections.Generic;
    using Api.Models;
    using Microsoft.AspNetCore.Mvc;

    public class HttpPutController : StandardController
    {
        [HttpPut("{key}")]
        public Dictionary<string, string> Put_1_FromBody_1_Constraint(string key, [FromBody] string value)
        {
            return this.ResponseDictionary(key, value, nameof(this.Put_1_FromBody_1_Constraint));
        }

        [HttpPut("{key}/{value}")]
        public Dictionary<string, string> Put_2_Constraint(string key, string value)
        {
            return this.ResponseDictionary(key, value, nameof(this.Put_2_Constraint));
        }
    }
}
