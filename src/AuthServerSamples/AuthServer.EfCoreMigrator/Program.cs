using AuthServerEfCore.Application.Migrator;
using AuthServerEfCore.DataLayer;
using AuthServerEfCore.PersistedGrant.DataLayer;
using CommandLine;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.EfCoreMigrator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // "PersistedGrant": "server=localhost;database=persisted_grants;username=postgres;password=postgres",
            // "Configuration": "server=localhost;database=configurations;username=postgres;password=postgres"

            args = "--dbContext Main -c server=database;port=5432;database=users;username=postgres;password=postgres".Split(" ");
            var parseResult = Parser.Default.ParseArguments<CmdOptions>(args);

            await parseResult.WithParsedAsync(Migrate);

            await parseResult.WithNotParsedAsync(HandleErrors);
        }

        static async Task Migrate(CmdOptions cmdOptions)
        {
            var serviceCollection = new ServiceCollection()
                .AddScoped<IMigratorService, MigratorService>();

            // this is just for fast development.
            // actual each database should have its own migrator
            switch (cmdOptions.DbContext)
            {
                case Enums.DbContext.Main:
                    serviceCollection.AddDbContext<DataContext>(opts =>
                    {
                        opts.UseNpgsql(cmdOptions.ConnectionString);
                        opts.EnableDetailedErrors();
                        opts.EnableSensitiveDataLogging();
                    });
                    break;
                case Enums.DbContext.Configuration:
                    serviceCollection.AddDbContext<ConfigurationContext>(opts =>
                    {
                        opts.UseNpgsql(cmdOptions.ConnectionString);
                        opts.EnableDetailedErrors();
                        opts.EnableSensitiveDataLogging();
                    });
                    break;
                case Enums.DbContext.PersistedGrant:
                    serviceCollection.AddDbContext<PersistedGrantContext>(opts =>
                    {
                        opts.UseNpgsql(cmdOptions.ConnectionString);
                        opts.EnableDetailedErrors();
                        opts.EnableSensitiveDataLogging();
                    });
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cmdOptions.DbContext));
            }

            var provider = serviceCollection.BuildServiceProvider();

            using var scope = provider.CreateScope();

            var migratorService = scope.ServiceProvider.GetRequiredService<IMigratorService>();

            await migratorService.MigrateAsync();
        }

        static async Task HandleErrors(IEnumerable<Error> errors)
        {
            var errorString = errors.Select(x => x.ToString()).Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");

            Console.WriteLine(errorString);
        }
    }
}
