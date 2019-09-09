namespace UnitTest
{
    using System;
    using System.IO;
    using System.Linq;
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
                var json = JsonConvert.SerializeObject(routeInfos, Formatting.Indented);
                Console.WriteLine(json);
                DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory);

                var file = Directory.GetFiles(di.Parent.Parent.Parent.Parent.FullName, "json.json", SearchOption.AllDirectories).FirstOrDefault();
                File.WriteAllText(file, json);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
