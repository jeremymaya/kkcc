using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoreanKirklandCentralChurch.Data;
using KoreanKirklandCentralChurch.Models;
using KoreanKirklandCentralChurch.Models.Interfaces;
using KoreanKirklandCentralChurch.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KoreanKirklandCentralChurch
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostEnvironment Environment { get; }

        public Startup(IHostEnvironment environment)
        {
            Environment = environment;
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            string churchConnString = Environment.IsDevelopment()
                ? Configuration["ConnectionStrings:ChurchDevelopmentConnection"]
                : Configuration["ConnectionStrings:ChurchProductionConnection"];

            // Registers the ChurchDbContext
            services.AddDbContext<ChurchDbContext>(options => options.UseSqlServer(churchConnString));

            string userConnString = Environment.IsDevelopment()
                ? Configuration["ConnectionStrings:UserDevelopmentConnection"]
                : Configuration["ConnectionStrings:UserProductionConnection"];

            services.AddDbContext<ChurchApplicationDbContext>(options => options.UseSqlServer(userConnString));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ChurchApplicationDbContext>().AddDefaultTokenProviders();

            services.AddAuthorization(options => options.AddPolicy("AdminOnly", policy => policy.RequireRole(ApplicationRoles.Admin)));

            // Registers the ISermon and SermonManager
            services.AddScoped<ISermon, SermonManager>();

            // Registers the IAlbum and AlbumManager
            services.AddScoped<IAlbum, AlbumManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            RoleInitializer.SeedData(serviceProvider);
        }
    }
}
