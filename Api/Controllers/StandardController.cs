namespace Api.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;

    public class StandardController : ControllerBase
    {
        protected Dictionary<string, string> ResponseDictionary(string key, string value, string url)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "key", key },
                { "value", value },
                { "url", url },
            };

            return dictionary;
        }
    }
}
