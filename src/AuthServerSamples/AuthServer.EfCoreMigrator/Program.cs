﻿using System;
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

            var connectionStringSection = configuration.GetSection("Database:ConnectionStrings:Auth").EnsureExistence();
            
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<DataContext>(connectionStringSection);

            serviceCollection.AddIdentityServer(connectionStringSection);

            var provider = serviceCollection.BuildServiceProvider();
        }

        static async Task HandleErrors(IEnumerable<Error> errors)
        {
            var errorString = errors.Select(x => x.ToString()).Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");

            Console.WriteLine(errorString);
        }
    }
}