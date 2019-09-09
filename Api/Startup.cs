namespace Api
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Route.Generator;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "API",
                    Description = "api文档",
                    TermsOfService = "None",
                });
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "api.xml");
                var xmlPathByModel = Path.Combine(basePath, "api.xml");
                options.IncludeXmlComments(xmlPathByModel);
                options.IncludeXmlComments(xmlPath, true);
            });

            services.AddMvc().AddJsonOptions((options) =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.Formatting = Formatting.Indented;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
            services.AddMvc(option => option.EnableEndpointRouting = true).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddRouteAnalyzer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseFileServer();
            app.UseSwagger();
            app.UseSwaggerUI(action =>
            {
                action.ShowExtensions();
                action.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            });

            app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                     name: "areaRoute",
                     template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute(
                //    name: "apiDefault",
                //    template: "api/{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller=Home}/{action=Index}/{id?}");
            });

            var mvcEndpointDataSource = app.ApplicationServices.GetRequiredService<IEnumerable<EndpointDataSource>>();
        }
    }
}
