using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.Common.Configuration;
using AuthServerEfCore.Application;
using AuthServerEfCore.Application.Migrator;
using AuthServerEfCore.DataLayer;
using AuthServerEfCore.Web.Common;
using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.EfCoreMigrator
{
    class Program
    {
        static async Task Main(string[] args)
        {
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

            var connectionStringSection = configuration.GetSection("Database:ConnectionStrings:Auth").EnsureExistence();

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<DataContext>(connectionStringSection);
            serviceCollection.AddApplication();
            serviceCollection.AddIdentity();
            serviceCollection.AddIdentityServer(connectionStringSection);

            var provider = serviceCollection.BuildServiceProvider();

            using var scope = provider.CreateScope();

            var migratorService = scope.ServiceProvider.GetRequiredService<IMigratorService>();

            await migratorService.MigrateAsync();

            await migratorService.SeedAsync();
        }

        static async Task HandleErrors(IEnumerable<Error> errors)
        {
            var errorString = errors.Select(x => x.ToString()).Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");

            Console.WriteLine(errorString);
        }
    }
}