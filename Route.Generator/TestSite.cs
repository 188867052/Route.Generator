﻿namespace Route.Generator
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;

    public class TestSite
    {
        private readonly string projectName;

        public TestSite(string projectname)
        {
            this.projectName = projectname;
        }

        public HttpClient BuildClient()
        {
            var dllFile = Directory.GetFiles(Environment.CurrentDirectory, $"{this.projectName}.dll", SearchOption.AllDirectories).FirstOrDefault();
            if (string.IsNullOrEmpty(dllFile))
            {
                throw new ArgumentException($"No {this.projectName}.dll file found under the directory: {Environment.CurrentDirectory}.");
            }

            Console.WriteLine($"this._projectName:{this.projectName}.");

            Console.WriteLine($"dllFile:{dllFile}.");

            Assembly assembly = Assembly.LoadFile(dllFile);
            Type type = assembly.GetTypes().FirstOrDefault(o => o.Name == "Startup");

            if (type == null)
            {
                throw new ArgumentException($"No Startup.cs class found under the dll file: {dllFile}.");
            }

            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseContentRoot(AppContext.BaseDirectory)
                .UseStartup(type);

            TestServer server = new TestServer(builder);
            var client = server.CreateClient();
            client.BaseAddress = new Uri("http://localhost");

            return client;
        }
    }
}