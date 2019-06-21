namespace Mvc.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("mvc")]
    public class AboutController
    {
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
