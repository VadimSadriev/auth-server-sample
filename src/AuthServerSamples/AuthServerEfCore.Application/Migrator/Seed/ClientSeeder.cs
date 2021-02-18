using System.Threading.Tasks;
using AuthServerEfCore.DataLayer;

namespace AuthServerEfCore.Application.Migrator.Seed
{
    /// <summary>
    /// Service for seeding database with clients
    /// </summary>
    public class ClientSeeder : ISeeder
    {
        private readonly ConfigurationContext _context;

        /// <summary>
        /// <inheritdoc cref="ClientSeeder"/>
        /// </summary>
        public ClientSeeder(ConfigurationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Task SeedAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}