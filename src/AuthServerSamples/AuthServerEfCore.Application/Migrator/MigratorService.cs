using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthServerEfCore.DataLayer;
using Microsoft.EntityFrameworkCore;

namespace AuthServerEfCore.Application.Migrator
{
    /// <summary>
    /// <inheritdoc cref="IMigratorService"/>
    /// </summary>
    public class MigratorService : IMigratorService
    {
        private readonly DataContext _context;
        private readonly ConfigurationContext _configurationContext;
        private readonly PersistedGrantContext _persistedGrantContext;
        private readonly IEnumerable<ISeeder> _seeders;

        /// <summary>
        /// <inheritdoc cref="MigratorService"/>
        /// </summary>
        public MigratorService(DataContext context, ConfigurationContext configurationContext, PersistedGrantContext persistedGrantContext, IEnumerable<ISeeder> seeders)
        {
            _context = context;
            _configurationContext = configurationContext;
            _persistedGrantContext = persistedGrantContext;
            _seeders = seeders;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task MigrateAsync()
        {
            try
            {
                Console.WriteLine($"{DateTime.Now:HH:mm:ss} Running migrations...");

                await _context.Database.MigrateAsync();
                await _configurationContext.Database.MigrateAsync();
                await _persistedGrantContext.Database.MigrateAsync();

                Console.WriteLine($"{DateTime.Now:HH:mm:ss} Migrations completed");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public async Task SeedAsync()
        {
            await using var useTransaction = await _context.Database.BeginTransactionAsync();
            await using var configTransaction = await _configurationContext.Database.BeginTransactionAsync();
            await using var persistedGrantTransaction = await _persistedGrantContext.Database.BeginTransactionAsync();

            Console.WriteLine($"{DateTime.Now:HH:mm:ss} Running seeders...");

            foreach (var seeder in _seeders)
            {
                await seeder.SeedAsync();
            }

            await useTransaction.CommitAsync();
            await configTransaction.CommitAsync();
            await persistedGrantTransaction.CommitAsync();

            Console.WriteLine($"{DateTime.Now:HH:mm:ss} Seeding completed...");
        }
    }
}