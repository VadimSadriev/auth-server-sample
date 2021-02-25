using System;
using AuthServer.Common.Logging;
using AuthServerEfCore.Application;
using AuthServerEfCore.DataLayer;
using AuthServerEfCore.Web.Common;
using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthServerEfCore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity();
            services.ConfigureApplicationCookie(opts =>
            {
                opts.Cookie.Name = "IdentityServer.Cookie";
                opts.LoginPath = "/auth/login";
                opts.LogoutPath = "/auth/logout";
            });
            services.AddIdentityServer(Configuration.GetSection("Database:ConnectionStrings:Auth"));

            services.AddDbContext<DataContext>(Configuration.GetSection("Database:ConnectionStrings:Auth"));
            services.AddApplication();
            services.AddAuthentication();

            services.AddSerilog(Configuration.GetSection("Logging"));
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
            }

            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax});
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }
    }
}