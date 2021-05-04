using AirportTickets.Data;
using AirportTickets.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportTickets
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
<<<<<<< Updated upstream
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
=======
            
            
            //services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
>>>>>>> Stashed changes
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
<<<<<<< Updated upstream
=======


            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Admin", policy =>
            //    {
            //        policy.RequireRole("Admin");
            //    });

            //    options.AddPolicy("User", policy =>
            //    {
            //        policy.RequireAssertion(x => x.User.IsInRole("User")
            //                                   || x.User.IsInRole("Admin"));
            //    });
            //});

            //services.AddAuthentication()
            //    .AddFacebook(config =>
            //    {
            //        config.AppId = Configuration["Authentication:Facebook:AppId"];
            //        config.AppSecret = Configuration["Authentication:Facebook:AppSecret"]; ;
            //    });

>>>>>>> Stashed changes
            services.AddRazorPages();
            services.AddTransient<IFlights, FlightsService>();
            services.AddTransient<IPassengers, PassengersService>();
            services.AddTransient<ITickets, TicketsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
