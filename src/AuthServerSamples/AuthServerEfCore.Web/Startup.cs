using System;
using AuthServer.Common.Logging;
using AuthServerEfCore.Configuration.DataLayer;
using AuthServerEfCore.DataLayer;
using AuthServerEfCore.PersistedGrant.DataLayer;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddIdentityServer()
                .AddOperationalStore<PersistedGrantContext>(opts =>
                {
                    opts.ConfigureDbContext = dbConfig =>
                    {
                        var assembly = typeof(PersistedGrantContext).Assembly.GetName().Name;

                        dbConfig.UseNpgsql(Configuration["Database:ConnectionStrings:PersistedGrant"],
                            npgsqlOpts => npgsqlOpts.MigrationsAssembly(assembly));

                        dbConfig.EnableDetailedErrors();
                        dbConfig.EnableSensitiveDataLogging();
                    };
                })
                .AddConfigurationStore<ConfigurationContext>(opts =>
                {
                    opts.ConfigureDbContext = dbConfig =>
                    {
                        var assembly = typeof(ConfigurationContext).Assembly.GetName().Name;
                        dbConfig.UseNpgsql(Configuration["Database:ConnectionStrings:Configuration"],
                             npgsqlOpts => npgsqlOpts.MigrationsAssembly(assembly));

                        dbConfig.EnableDetailedErrors();
                        dbConfig.EnableSensitiveDataLogging();
                    };
                });

            services.AddScoped<IPersistedGrantDbContext, PersistedGrantContext>();
            services.AddScoped<IConfigurationDbContext, ConfigurationContext>();

            services.AddDbContext<DataContext>(opts =>
            {
                opts.UseNpgsql(Configuration["Database:ConnectionStrings:Users"]);
                opts.EnableDetailedErrors();
                opts.EnableSensitiveDataLogging();
            });

            services.AddSerilog(Configuration);
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

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
