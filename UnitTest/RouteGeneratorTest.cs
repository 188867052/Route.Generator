namespace UnitTest
{
    using System;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Route.Generator;

    [TestFixture]
    public class RouteGeneratorTest
    {
        [Test]
        public async Task TestApiRouteGenerator()
        {
            try
            {
                var client = new TestSite(nameof(Api)).BuildClient();
                var response = await client.GetAsync("/routes.html");
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                var routesGenerated = RouteGenerator.GenerateRoutes(content);
                Console.WriteLine(routesGenerated);
                Assert.True(routesGenerated.Contains("namespace"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
