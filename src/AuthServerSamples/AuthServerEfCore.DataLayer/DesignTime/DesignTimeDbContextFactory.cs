using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.FileProviders;

namespace AuthServerEfCore.DataLayer.DesignTime
{
    /// <summary>
    /// <inheritdoc cref="DesignTimeDbContextFactory{TContext}"/>
    /// </summary>
    public abstract class DesignTimeDbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext>
        where TContext : DbContext
    {
        private readonly string Environment = "Development";
        protected abstract string AppSettingsPath { get; }
        protected abstract string ConfigurationName { get; }

        public abstract TContext CreateContext(DbContextOptions<TContext> options);

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public TContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();

            var configSources = new List<JsonConfigurationSource>()
            {
                new JsonConfigurationSource
                {
                    Optional = true,
                    Path = $"appsettings.{Environment}.json",
                    FileProvider = new PhysicalFileProvider(AppSettingsPath)
                }
            };

            configSources.ForEach(x => configurationBuilder.Sources.Add(x));

            var configuration = configurationBuilder.Build();

            var connectionString = configuration[ConfigurationName];

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException($"Please provider connection string in appsettings.{Environment}.json file in order to create db context");

            Console.WriteLine($"Environment: {Environment}");
            Console.WriteLine($"Creating {nameof(TContext)}. Connection string: {connectionString}");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            optionsBuilder.UseNpgsql(connectionString);

            return CreateContext(optionsBuilder.Options);
        }
    }
}