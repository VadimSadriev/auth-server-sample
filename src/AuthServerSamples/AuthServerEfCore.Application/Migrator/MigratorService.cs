using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AuthServerEfCore.Application.Migrator
{
    /// <summary>
    /// <inheritdoc cref="IMigratorService"/>
    /// </summary>
    public class MigratorService : IMigratorService
    {
        private readonly DbContext _context;

        /// <summary>
        /// <inheritdoc cref="MigratorService"/>
        /// </summary>
        /// <param name="context"></param>
        public MigratorService(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task MigrateAsync()
        {
            try
            {
                Console.WriteLine($"{DateTime.Now:HH:mm:ss} Running migration...");

                await _context.Database.MigrateAsync();

                Console.WriteLine($"{DateTime.Now:HH:mm:ss} Migration completed");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
