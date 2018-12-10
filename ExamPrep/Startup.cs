using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamPrep.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ExamPrep
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env,
                              IGreeter greeter, ILogger<Startup> logger)  
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Serverer static filer samt Default files i en metode
            //app.UseFileServer();

            app.UseStaticFiles();

            //Router request gennem MVC framework - til Controller klassen
            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessageOfTheDay();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Not found");
            });
        }

        //Dette er Conventional Routing:
        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //Her Router jeg de requests jeg får til min Home/index. ? = Hvis ID så gør noget,  hvis ikke så gør intet!
            // /Home/Index/4
            routeBuilder.MapRoute("Default", 
                "{controller=Home}/{action=Index}/{id?}");
        }

        ////MiddleWare der behandler requests - når den rammer /mym siger den en ting, når den rammer /wp gør den noget andet:
        //app.Use(next => { return async context =>
        //    {
        //        logger.LogInformation("Request incoming");
        //        if (context.Request.Path.StartsWithSegments("/mym"))
        //        {
        //            await context.Response.WriteAsync("Hit!!");
        //            logger.LogInformation("Request handled");
        //        }
        //        else
        //        {
        //            await next(context);
        //            logger.LogInformation("Response outgoing");
        //        }
        //    };
        //});

        //app.UseWelcomePage(new WelcomePageOptions
        //    {
        //        Path ="/wp"
        //    });


    }
}
