namespace UnitTest
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Routing;
    using NUnit.Framework;
    using Route.Generator;

    [TestFixture]
    public class RouteGeneratorTest
    {
        [Test]
        public async Task TestMvcRouteGenerator()
        {
            try
            {
                using var client = new TestSite(nameof(Mvc)).BuildClient();
                var response = await client.GetAsync(Router.DefaultRoute);
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

        [Test]
        public async Task TestApiRouteGenerator()
        {
            try
            {
                using var client = new TestSite(nameof(Api)).BuildClient();
                var response = await client.GetAsync(Router.DefaultRoute);
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
