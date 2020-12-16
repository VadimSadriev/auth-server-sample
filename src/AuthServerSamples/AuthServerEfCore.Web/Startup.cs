using AuthServer.Common.Logging;
using AuthServerEfCore.PersistedGrant.DataLayer;
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
                        dbConfig.UseNpgsql(Configuration["Database:ConnectionStrings:PersistedGrant"],
                            npgsqlOpts => npgsqlOpts.MigrationsAssembly(typeof(PersistedGrantContext).Assembly.GetName().Name));
                        dbConfig.EnableDetailedErrors();
                        dbConfig.EnableSensitiveDataLogging();
                    };
                })

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
