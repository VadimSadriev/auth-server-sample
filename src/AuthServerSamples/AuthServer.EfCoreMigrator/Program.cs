using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.Common.Configuration;
using AuthServerEfCore.DataLayer;
using CommandLine;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AuthServerEfCore.Web.Common;

namespace AuthServer.EfCoreMigrator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            args = "-e Development".Split(" ");

            var parseResult = Parser.Default.ParseArguments<CmdOptions>(args);

            await parseResult.WithParsedAsync(MigrateAsync);

            await parseResult.WithNotParsedAsync(HandleErrors);
        }

        static async Task MigrateAsync(CmdOptions options)
        {
            var environmentName = options.Environment;

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json")
                .Build();

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<DataContext>(configuration.GetSection("Database:ConnectionStrings:Users"));

            serviceCollection
                .AddIdentityServer()
                .AddConfigurationStore<ConfigurationContext>(opts =>
                {
                    opts.ConfigureDbContext = dbConfig =>
                    {
                        var assembly = typeof(ConfigurationContext).Assembly.GetName().Name;
                        dbConfig.UseNpgsql(configuration.GetSection("Database:ConnectionStrings:Configuration").EnsureExistence().Value,
                            npgsqlOpts => npgsqlOpts.MigrationsAssembly(assembly));

                        dbConfig.EnableDetailedErrors();
                        dbConfig.EnableSensitiveDataLogging();
                    };
                })
                .AddOperationalStore<PersistedGrantContext>(opts =>
                {
                    opts.ConfigureDbContext = dbConfig =>
                    {
                        var assembly = typeof(PersistedGrantContext).Assembly.GetName().Name;

                        dbConfig.UseNpgsql(configuration.GetSection("Database:ConnectionStrings:PersistedGrant").EnsureExistence().Value,
                            npgsqlOpts => npgsqlOpts.MigrationsAssembly(assembly));

                        dbConfig.EnableDetailedErrors();
                        dbConfig.EnableSensitiveDataLogging();
                    };
                });

            var provider = serviceCollection.BuildServiceProvider();

            using var scope = provider.CreateScope();

            var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();

            Console.WriteLine($"Migrating {dataContext.GetType()}");
            await dataContext.Database.MigrateAsync();
            Console.WriteLine($"End migration {dataContext.GetType()}");

            var configurationContext = scope.ServiceProvider.GetRequiredService<ConfigurationContext>();

            Console.WriteLine($"Migrating {configurationContext.GetType()}");
            await configurationContext.Database.MigrateAsync();
            Console.WriteLine($"End migration {configurationContext.GetType()}");

            var persistedGrantContext = scope.ServiceProvider.GetRequiredService<PersistedGrantContext>();

            Console.WriteLine($"Migrating {persistedGrantContext.GetType()}");
            await persistedGrantContext.Database.MigrateAsync();
            Console.WriteLine($"End migration {persistedGrantContext.GetType()}");
        }

        static async Task HandleErrors(IEnumerable<Error> errors)
        {
            var errorString = errors.Select(x => x.ToString()).Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");

            Console.WriteLine(errorString);
        }
    }
}