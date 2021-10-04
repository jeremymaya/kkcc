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
        public IWebHostEnvironment WebHostEnvironment { get; }

        public Startup(IWebHostEnvironment webHostEnvironment)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
            WebHostEnvironment = webHostEnvironment;
        }

        // Source: https://n1ghtmare.github.io/2020-09-28/deploying-a-dockerized-aspnet-core-app-using-a-postgresql-db-to-heroku/
        private string GetHerokuConnectionString(string connectionString)
        {
            // Get the connection string from the ENV variables
            string connectionUrl = Environment.GetEnvironmentVariable(connectionString);

            // parse the connection string
            var databaseUri = new Uri(connectionUrl);

            string db = databaseUri.LocalPath.TrimStart('/');
            string[] userInfo = databaseUri.UserInfo.Split(':', StringSplitOptions.RemoveEmptyEntries);

            return $"User ID={userInfo[0]};Password={userInfo[1]};Host={databaseUri.Host};Port={databaseUri.Port};Database={db};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            // Registers the ChurchDbContext
            services.AddDbContext<ChurchDbContext>(options => options.UseNpgsql(GetHerokuConnectionString("CHURCH_PINK_ARG")));

            // Registers the ChurchApplicationDbContext
            services.AddDbContext<ChurchApplicationDbContext>(options => options.UseNpgsql(GetHerokuConnectionString("APPLICATION_CRIMSON_ARG")));

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
