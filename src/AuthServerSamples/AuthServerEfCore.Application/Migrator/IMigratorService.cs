using System.Threading.Tasks;

namespace AuthServerEfCore.Application.Migrator
{
    /// <summary>
    /// Service for database migrations
    /// </summary>
    public interface IMigratorService
    {
        /// <summary>
        /// Migrates database
        /// </summary>
        Task MigrateAsync();
    }
}
