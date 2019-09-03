namespace UnitTest
{
    using System;
    using Newtonsoft.Json;
    using Xunit;

    public class RouteGeneratorTest
    {
        [Fact]
        public void TestApiRouteGenerator()
        {
            try
            {
                var routeInfos = new TestSite(nameof(Api)).GetAllRouteInfo();
                Console.WriteLine(JsonConvert.SerializeObject(routeInfos, Formatting.Indented));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
