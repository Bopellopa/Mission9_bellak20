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
using WaterProject.Models;

namespace WaterProject
{
    public class Startup
    {
        // IConfiguration is used to retrieve configuration values
        public IConfiguration Configuration { get; set; }

        // Constructor that receives IConfiguration instance
        public Startup(IConfiguration temp)
        {
            Configuration = temp;
        }

        // This method is used to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Adds services for controllers and views
            services.AddControllersWithViews();

            // Adds DbContext for BookstoreContext with SQLite
            services.AddDbContext<BookstoreContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookstoreDBConnection"]);
            });

            // Adds EFBookstoreRepository as a scoped service
            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();

            // Adds Razor Pages as a service
            services.AddRazorPages();

            // Adds Distributed Memory Cache
            services.AddDistributedMemoryCache();

            // Adds Session
            services.AddSession();

            // Adds Basket as a scoped service using SessionBasket.GetBasket method
            services.AddScoped<Basket>(x => SessionBasket.GetBasket(x));
        }

        // This method is used to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // If the environment is Development, use the DeveloperExceptionPage
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Use Static Files
            app.UseStaticFiles();

            // Use Routing
            app.UseRouting();

            // Use Session
            app.UseSession();

            // Use Endpoints to map the URLs to Controllers and Actions
            app.UseEndpoints(endpoints =>
            {
                // Maps the URL for a category page with a specified page number to the Home controller and Index action
                endpoints.MapControllerRoute("categorypage", "{category}/Page{pageNum}", new { Controller = "Home", action = "Index" });

                // Maps the URL for a page with a specified page number to the Home controller and Index action
                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Index", pageNum = 1 });

                // Maps the URL for a category to the Home controller and Index action
                endpoints.MapControllerRoute("category", "{category}", new { Controller = "Home", action = "Index", pageNum = 1 });

                // Maps the default route for the Controller
                endpoints.MapDefaultControllerRoute();

                // Maps Razor Pages
                endpoints.MapRazorPages();
            });
        }
    }
}

