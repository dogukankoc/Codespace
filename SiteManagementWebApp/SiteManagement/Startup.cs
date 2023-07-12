using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using SiteManagement.Models.Db;
using SiteManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement
{
    public class Startup
    {
        public readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            AppSettings.ConnectionString = _configuration.GetConnectionString("MSSQLServer");

            services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddSession();
            services.AddDbContext<SiteManagementDbContext>();
            services.AddTransient<CommonService>();
            services.AddTransient<SiteService>();
            services.AddTransient<BlockService>();
            services.AddTransient<ApartmentService>();
            services.AddTransient<ResidentService>();
            services.AddTransient<WorkerService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Auth}/{action=Login}/{id?}");

                //endpoints.MapControllerRoute("UpdateSite","{controller=Management}/{action=UpdateSite}/{id}");
                endpoints.MapControllerRoute("Login", "giris", new { controller = "Auth", action = "Login" });
                endpoints.MapControllerRoute("Home", "anasayfa", new { controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("Register", "kayitol", new { controller = "Auth", action = "register" });
                endpoints.MapControllerRoute("Management", "yonetim", new { controller = "Management", action = "Index" });
            });
        }
    }
}
