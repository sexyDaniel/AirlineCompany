using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IdentityServer4;
using IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity
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
            services.AddDbContext<AuthDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<User, IdentityRole>(config=> 
            {
                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 3;
                config.Password.RequireUppercase = false;
                config.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer(options=> 
            {
                options.UserInteraction.LoginUrl = "/Auth/Login";
            })
                .AddAspNetIdentity<User>()
                .AddInMemoryApiScopes(IdentityConfiguration.Scopes)
                .AddInMemoryApiResources(IdentityConfiguration.ApiResources)
                .AddInMemoryClients(IdentityConfiguration.Clients)
                .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
                .AddDeveloperSigningCredential();

            services.ConfigureApplicationCookie(conf=> 
            {
                conf.Cookie.Name = "Forms.Identity.Cookie";
                conf.LoginPath = "/Auth/Login";
                conf.LogoutPath = "/Auth/Logout";
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
