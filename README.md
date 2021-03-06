## Master
[![Build Status](https://542153354-qq.visualstudio.com/Route.Generator/_apis/build/status/188867052.Route.Generator?branchName=master)](https://542153354-qq.visualstudio.com/Route.Generator/_build/latest?definitionId=12&branchName=master)
## Code Gen
[![Build Status](https://542153354-qq.visualstudio.com/Route.Generator/_apis/build/status/%E4%BB%A3%E7%A0%81%E7%94%9F%E6%88%90%E5%99%A8?branchName=master)](https://542153354-qq.visualstudio.com/Route.Generator/_build/latest?definitionId=17&branchName=master)

| Package | NuGet Stable | Downloads |
| ------- | ------------ | --------- |
| [Route.Generator](https://www.nuget.org/packages/Route.Generator/) | [![Route.Generator](https://img.shields.io/nuget/v/Route.Generator.svg)](https://www.nuget.org/packages/Route.Generator/) | [![Route.Generator](https://img.shields.io/nuget/dt/Route.Generator.svg)](https://www.nuget.org/packages/Route.Generator/) | 

## Install NuGet package
- [NuGet Gallery | Route.Generator](https://www.nuget.org/packages/Route.Generator/)

```
PM> Install-Package Route.Generator
```

## Edit Startup.cs
Insert code ```services.AddRouteAnalyzer();``` and required ```using``` directive into Startup.cs as follows.

```cs
using Route.Generator; // Add
....
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    services.AddRouteAnalyzer(); // Add
}
....
```
## View Routes via Browser
```
Eg. input http://localhost:27634/routes.html
```
![screenshot](https://github.com/188867052/Route.Generator/blob/master/Route.Generator/routes.html.png)
```
Eg. input http://localhost:27634/routes, the address is used to generate async methods, 
please make it accessible.
```
![screenshot](https://github.com/188867052/Route.Generator/blob/master/Route.Generator/routes.json.png)

## Generate Routes and Async Methods

If you want more powerful features, you can install 
Route.Generator.CLI to Generate Routes Generated Files
- [NuGet Gallery | Route.Generator.CLI](https://www.nuget.org/packages/Route.Generator.CLI/)

```
PM> Install-Package Route.Generator.CLI
PM> routegen gen -p <Your project name> -u <The base address>
Eg. routegen gen -p Api -u http://localhost:27634/
```
## Command-line Options

command | description   
-|-
-p | Your project name 
-u | The base address 
-o | The out put file name. default name is Routes.Generated.cs.
-g | Whether generate async method or not, 1 or true meanings will generate, otherwise will not.

## Technologies

* [CommandLineUtils](https://github.com/natemcmaster/CommandLineUtils)
* [ASP.NET Core 2.1](https://docs.microsoft.com/en-us/aspnet/core)
* [C# 7.3](https://docs.microsoft.com/en-us/dotnet/csharp)
* [XUnit](https://github.com/XUnit/XUnit)
* [Serilog](https://github.com/serilog/serilog)

## Unit Tests

* [Http Delete Unit Test](https://github.com/188867052/Route.Generator/blob/master/UnitTest/HttpClientDeleteAsyncTest.cs)
* [Http Get Unit Test](https://github.com/188867052/Route.Generator/blob/master/UnitTest/HttpClientGetAsyncTest.cs)
* [Http Patch Unit Test](https://github.com/188867052/Route.Generator/blob/master/UnitTest/HttpClientPatchAsyncTest.cs)
* [Http Post Unit Test](https://github.com/188867052/Route.Generator/blob/master/UnitTest/HttpClientPostAsyncTest.cs)
* [Http Put Unit Test](https://github.com/188867052/Route.Generator/blob/master/UnitTest/HttpClientPutAsyncTest.cs)
* [Route Generator Unit Test](https://github.com/188867052/Route.Generator/blob/master/UnitTest/RouteGeneratorTest.cs)

## Supported Http Methods

* [Get]
* [Post]
* [Delete]
* [Post]
* [Put]

## Generated Files

* [Mvc-Generated Routes](https://github.com/188867052/Route.Generator/blob/master/Mvc/Routes.Generated.cs)
* [Api-Generated Routes and Async Methods](https://github.com/188867052/Route.Generator/blob/master/Api/Routes.Generated.cs)

## Route Generator Project

* [See Code](https://github.com/188867052/Route.Generator/tree/master/Route.Generator)

## Examples

```cs
[Route("api/[controller]/[action]")]
[ApiController]
public class ExampleController : StandardController
{
    [HttpGet("{key}")]
    public Dictionary<string, string> GetVlues(string key, string value)
    {
        return this.ResponseDictionary(key, value, nameof(this.GetVlues));
    }

    [HttpPost]
    public Dictionary<string, string> Edit(PointModel model)
    {
        return this.ResponseDictionary(null, null, nameof(this.Edit));
    }

    [HttpDelete]
    public Dictionary<string, string> Delete(string id)
    {
        return this.ResponseDictionary(null, null, nameof(this.Delete));
    }
}
```

```cs
/// <summary>
/// <see cref="Controllers.ExampleController"/>
/// </summary>
public class ExampleRoute
{
    /// <summary>
    /// <see cref="Controllers.ExampleController.GetVlues"/>
    /// </summary>
    public const string GetVlues = "/api/Example/GetVlues/{key}";
    public static async Task<T> GetVluesAsync<T>(string key, string value)
    {
        var routeInfo = new RouteInfo
        {
            HttpMethods = "GET",
            Path = GetVlues,
            Parameters = new List<ParameterInfo>
            {
                new ParameterInfo() {Name = "key", Type = "string"},
                new ParameterInfo() {Name = "value", Type = "string"},
            }
        };
        return await HttpClientAsync.Async<T>(routeInfo, key, value);
    }

    /// <summary>
    /// <see cref="Controllers.ExampleController.Edit"/>
    /// </summary>
    public const string Edit = "/api/Example/Edit";
    public static async Task<T> EditAsync<T>(Api.Models.PointModel model)
    {
        var routeInfo = new RouteInfo
        {
            HttpMethods = "POST",
            Path = Edit,
            Parameters = new List<ParameterInfo>
            {
                new ParameterInfo() {Name = "model", Type = "Api.Models.PointModel"},
            }
        };
        return await HttpClientAsync.Async<T>(routeInfo, model);
    }

    /// <summary>
    /// <see cref="Controllers.ExampleController.Delete"/>
    /// </summary>
    public const string Delete = "/api/Example/Delete";
    public static async Task<T> DeleteAsync<T>(string id)
    {
        var routeInfo = new RouteInfo
        {
            HttpMethods = "DELETE",
            Path = Delete,
            Parameters = new List<ParameterInfo>
            {
                new ParameterInfo() {Name = "id", Type = "string"},
            }
        };
        return await HttpClientAsync.Async<T>(routeInfo, id);
    }
}
```

```cs
/// <summary>
/// <see cref="Controllers.HomeController"/>
/// </summary>
public class HomeRoute
{
    /// <summary>
    /// <see cref="Controllers.HomeController.Index"/>
    /// </summary>
    public const string Index = "/Admin/Home/Index";

    /// <summary>
    /// <see cref="Controllers.HomeController.About"/>
    /// </summary>
    public const string About = "/Admin/Home/About";

    /// <summary>
    /// <see cref="Controllers.HomeController.Contact"/>
    /// </summary>
    public const string Contact = "/Admin/Home/Contact";

    /// <summary>
    /// <see cref="Controllers.HomeController.Privacy"/>
    /// </summary>
    public const string Privacy = "/Admin/Home/Privacy";

    /// <summary>
    /// <see cref="Controllers.HomeController.Error"/>
    /// </summary>
    public const string Error = "/Admin/Home/Error";
}
```
## My projects
* [EFCore.Scaffolding.Extension](https://github.com/188867052/EFCore.Scaffolding.Extension)
* [DependencyInjection.Analyzer](https://github.com/188867052/DependencyInjection.Analyzer)
* [Route.Generator](https://github.com/188867052/Route.Generator)
* [MatrixAdmin](https://github.com/188867052/MatrixAdmin)
* [DapperExtension](https://github.com/188867052/DapperExtension)
* [Quartz.Web](https://github.com/188867052/Quartz.Web)
