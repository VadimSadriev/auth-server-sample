﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AuthServerEfCore.DataLayer;
using IdentityModel;
using IdentityServer4;
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
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client_id_mvc",
                    ClientSecrets = { new Secret("client_secret_mvc".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },

                    RequirePkce = true,

                    PostLogoutRedirectUris = { "http://localhost:5002/home/index" },
                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    AllowOfflineAccess = true
                },
                new Client
                {
                    ClientId = "consumer_api",
                    ClientSecrets = new List<Secret> { new Secret("consumer_api_secret".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "OrderApi", "read", "rc.scope" },
                    Claims = new List<ClientClaim>
                    {
                        new ClientClaim("server.character", "Xayah"),
                        new ClientClaim("orderapi.claim", "apiclaim"),
                    }
                },
                new Client
                {
                    ClientId = "react_app_id",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    AllowedScopes =
                    {
                        "OrderApi",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    RedirectUris = { "http://localhost:3000/authentication/callback" }
                    // AllowAccessTokensViaBrowser = true
                }
            };
        }

        /// <summary>
        /// List of api scopes to seed
        /// </summary>
        private IList<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("OrderApi", new[] { " orderapi.claim" }),
                new ApiScope("read"),
            };
        }

        /// <summary>
        /// List of identity resources to seed
        /// </summary>
        private IList<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "rc.scope",
                    UserClaims = { "server.character" }
                }
            };
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