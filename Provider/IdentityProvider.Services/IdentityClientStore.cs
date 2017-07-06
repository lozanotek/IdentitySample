using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;

namespace IdentityProvider.Services
{
    public class IdentityClientStore : IClientStore
    {
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var client = new Client
            {
                Enabled = true,
                ClientName = "client1",
                ClientId = "client1",
                Flow = Flows.Hybrid,
                RequireConsent = false,
                AccessTokenType = AccessTokenType.Jwt,
                ClientSecrets = new List<Secret>
                {
                    new Secret("test".Sha256())
                },
                AllowedScopes = new List<string>
                {
                    Constants.StandardScopes.OpenId,
                    Constants.StandardScopes.Profile,
                    Constants.StandardScopes.Email,
                    Constants.StandardScopes.Roles
                },
                RedirectUris = new List<string>
                {
                    "http://localhost:4567/"
                },
                PostLogoutRedirectUris = new List<string>
                {
                    "http://localhost:4567/"
                }
            };

            return Task.FromResult(client);
        }
    }
}