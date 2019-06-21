namespace Mvc.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("Simple")]
    public class SimpleController
    {
        [Route("me")]
        public string Me()
        {
            return "mike";
        }

        [Route("company")]
        public string Company()
        {
            return "no company";
        }
    }
}
