using System.Threading.Tasks;

namespace AuthServerEfCore.Application.Migrator
{
    /// <summary>
    /// Service for seeding database 
    /// </summary>
    public interface ISeeder
    {
        /// <summary>
        /// Seeds database
        /// </summary>
        Task SeedAsync();
    }
}