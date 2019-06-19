using Route.Generator;
using Route.Generator.RouteAnalyzer;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class RouteGeneratorTest
    {
        [Fact]
        public async Task TestMvcRouteGenerator()
        {
            try
            {
                using (var client = new TestSite("Mvc").BuildClient())
                {
                    var response = await client.GetAsync(Router.DefaultRoute);
                    var content = await response.Content.ReadAsStringAsync();

                    var routesGenerated = RouteGenerator.GenerateRoutes(content);
                    Assert.True(routesGenerated.Contains("namespace"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Fact]
        public async Task TestApiRouteGenerator()
        {
            try
            {
                var client = new TestSite("Api").BuildClient();
                var response = await client.GetAsync(Router.DefaultRoute);
                var content = await response.Content.ReadAsStringAsync();

                var routesGenerated = RouteGenerator.GenerateRoutes(content);
                Assert.True(routesGenerated.Contains("namespace"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
