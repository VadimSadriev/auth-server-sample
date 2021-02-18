using System.Collections.Generic;
using System.Threading.Tasks;
using AuthServerEfCore.DataLayer;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;

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
        public async Task SeedAsync()
        {
            var clients = GetClients();

            foreach (var client in clients)
            {
                await _context.AddOrUpdateAsync(client.ToEntity(), x => x.ClientId == client.ClientId);
            }

            var apiScopes = GetApiScopes();

            foreach (var apiScope in apiScopes)
            {
                await _context.AddOrUpdateAsync(apiScope.ToEntity(), x => x.Name == apiScope.Name);
            }

            var identityResources = GetIdentityResources();

            foreach (var identityResource in identityResources)
            {
                await _context.AddOrUpdateAsync(identityResource.ToEntity(), x => x.Name == identityResource.Name);
            }

            var apiResources = GetApiResources();

            foreach (var apiResource in apiResources)
            {
                await _context.AddOrUpdateAsync(apiResource.ToEntity(), x => x.Name == apiResource.Name);
            }

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// List of auth server clients to seed
        /// </summary>
        private IList<Client> GetClients()
        {
            return new List<Client>();
        }

        /// <summary>
        /// List of api scopes to seed
        /// </summary>
        private IList<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>();
        }

        /// <summary>
        /// List of identity resources to seed
        /// </summary>
        private IList<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>();
        }

        /// <summary>
        /// List of api resources to seed
        /// </summary>
        private IList<ApiResource> GetApiResources()
        {
            return new List<ApiResource>();
        }
    }
}