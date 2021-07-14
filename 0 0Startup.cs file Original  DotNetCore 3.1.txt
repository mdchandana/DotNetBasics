using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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


        /*===============Setup MVC in Asp.Net Core =================================
        Step 1 : Add Mvc services to the Dependency Injection Container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }


        Step 2 : Add MVC middleware to the Request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
        =============================================================================*/

        /* 
        * Here IConfiguration service is setup to read configuration information from all the various configuration -
        * sources in asp.net core
        * To access configuration information in the Startup class, inject the IConfiguration service provided by -
        * the Framework. Startup class is in Startup.cs file.
        * use constructor injections to inject Iconfiguaration service
        */

        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // New Added By Me 1 =======

            //================fixing endpoint routing error============================
            //======If migrating from 2.2 to 3.0, please use the below code to fix endpoint routing error
            //solution 1 worked
            //services.AddMvc(enspoints => enspoints.EnableEndpointRouting = false);

            //solution 2 worked
            //services.AddControllers(options => options.EnableEndpointRouting = false);
            //=========================================================================

            // adding mvc services to the dependency injection container 
            //services.AddMvc();

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;  //to fix endpointroute error .. with dotnetcore 3.1

                ////apply authorize attribute globally, instead of appliying it to each controllers
                ////applying authorize to all the controllers globally...
                ///* with this authorization policy, we are saying to reach any of the controllers or
                //   their actions withing our application we want users to be authenticated...
                // */
                //var policy = new AuthorizationPolicyBuilder()
                //               .RequireAuthenticatedUser()
                //               .Build();                       //--build the authorization policy

                //options.Filters.Add(new AuthorizeFilter(policy));
            });

            //services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
            //services.AddScoped<IEmployeeRepository, MockEmployeeRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //services.AddScoped<DepartmentRepository>();

            /* New Added By Me 1 ======= */
            services.AddDbContextPool<AppDbContext>(options =>
                 options.UseSqlServer(_configuration.GetConnectionString("VenkatCoreDBConnString")));

            //adding identity services
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<AppDbContext>();

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<AppDbContext>();

            //----------------configure using IdentityOptions-----------------------------------
            //services.Configure<IdentityOptions>(options =>
            //{
            //    //----------------Overide PasswordOptions default settings using IdentityOptions-----------
            //    options.Password.RequiredLength = 4;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireUppercase = false;
            //    //options.Password.RequiredUniqueChars = 
            //}
            //);


        }




        /*
        * 'Configure()' method set the request procesign pipeline for our asp.net core application
        */

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                ///*If it is a error ocuur regarding Invalid path , This is displaying, just a 404 error message */
                //app.UseStatusCodePages();

                ///*If it is a error ocuur regarding Invalid path,This wll call the 'ErrorController' and
                //pass the status code to ErrorController Action method */
                ////app.UseStatusCodePagesWithRedirects("/Error/{0}");

                ///*this is one also same as UseStatusCodePagesWithRedirects, difference is -
                // app.UseStatusCodePagesWithReExecute method doesn't change the url.....*/
                ////app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }



            /*
             * New Added By Me  this middleware=======
             * 'UseDefaultFiles()' method should be before 'UseStaticFiles()' -
             * otherwise it is not working 'UseDefaultFiles()'
            */
            //app.UseDefaultFiles();


            /* New Added By Me  this middleware=======
             * This is directory browsing middleware..
             * It enables directory browsing and allows end user to see the list of files and -
             * folders in specified directory...
             */
            app.UseStaticFiles();




            //this should be addde before the 'UseMvc' middleware
            //app.UseAuthentication();

            //--2
            //--Add Mvc moddleware to the Request Pipeline With default Route
            //--This method add Request processign Pipeline for With default Route
            //--With Default Route : '{controller=Home}/{action=Index}/{id?}'
            //app.UseMvcWithDefaultRoute();

            //--Add Mvc moddleware to the Request Pipeline Without Route
            //--Now Here we don't have any route configured, as a result Our application doesn't know how to handle incoming urls
            //--Displaying HTTP ERROR 404 When we Requesting https://localhost:44324/home/index
            //--ERROR : No webpage was found for the web address: https://localhost:44324/home/index
            //app.UseMvc();   //Here solution:Attribute routing


            //this authentication middleware should be added before the mvc middleware
            //app.UseAuthentication();





            //--Now configured Route - WORKED
            app.UseMvc(routes =>
            {
                //routes.MapRoute("default", "{controller}/{action}/{id?}");
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");    //Assigned default controller and index
            });


            //BY ME           
            /*
             * here app.Run() middleware passes http context object as a parameter to this anonymouse method...
             * using this context object , app.Run() middleware gains access to incoming http request and outgoing http response .. 
             * context object have request and response properties...
             */
            /* app.Run() is a Terminal middleware, Terminal middleware doesn't call to the next middleware in the pipeline..   
             * it handles the request , produces the response and pipeline reverses itself...
             */
            app.Run(async (context) =>
            {
                //throw new Exception("Some error processing the request");
                await context.Response.WriteAsync("Hello World!");

                ///Worked accessing appsettings.json ..........
                //await context.Response.WriteAsync("FullName : " + _configuration["MyName:FirstName"] + " " + _configuration["MyName:LastName"] + "\t"
                //                                 + "VenkatCoreConnString : " + _configuration["ConnectionStrings:VenkatCoreDBConnString"] + "\t"
                //                                 + "ByConnectionStrings :" + _configuration.GetConnectionString("VenkatCoreDBConnString"));
            });





            //CREATED BY PROJECT, Commented

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello world!"); 
            //    });
            //});
        }
    }
}
