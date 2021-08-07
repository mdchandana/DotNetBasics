using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenkatCore.Models;

namespace VenkatCore
{

    /*
   * Startup class does the following 2 very important things
   * 1. ConfigureServices() method configures services required by the application
   * 2. Configure() method sets up the application's request processing pipeline
   */


    public class Startup
    {


        /*
        * 'Dependency Injection' In previous versions of ASP.NET Dependency Injection was optional and to configure -
        * it we have to use frameworks like Ninject, StructureMap etc. In ASP.NET Core Dependency Injection is an -
        * integral part. Dependency Injection allow us to create systems that are loosely coupled, extensible and -
        * easily testable.
        */



        private IConfiguration _config;
        /* 
        * Here IConfiguration service is setup to read configuration information from all the various configuration -
        * sources in asp.net core
        * To access configuration information in the Startup class, inject the IConfiguration service provided by -
        * the Framework. Startup class is in Startup.cs file.
        * use constructor injections to inject Iconfiguaration service
        */
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }





        /*===============Setup MVC in Asp.Net Core =================================
        Step 1 : Add Mvc services to the Dependency Injection Container*/

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            //--Dotnet 5
            services.AddControllersWithViews();

            //services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
            services.AddScoped<IEmployeeRepository, SqlEmployeeRepository>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_config.GetConnectionString("VenkatCoreConnString")));    
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            //--Dotnet 5
            //ASP.NET Core Web App (Model-View-Controller)  (mvc)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employee}/{action=Index}/{id?}");
            });



            //--Dotnet 5
            //ASP.NET Core Empty web
            //MVC TagHelpers are not work corectly with this End point ..
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
