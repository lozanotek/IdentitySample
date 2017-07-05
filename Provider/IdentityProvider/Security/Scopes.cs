using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace IdentityProvider.Security
{
    public sealed class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope>
            {
                StandardScopes.Email,
                StandardScopes.OpenId,
                StandardScopes.ProfileAlwaysInclude,
                StandardScopes.Roles
            };
        }
    }
}