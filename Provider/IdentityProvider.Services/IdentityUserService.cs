using System;
using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.Default;

namespace IdentityProvider.Services
{

    public class DemoUserService : IUserService
    {
        public Task PreAuthenticateAsync(PreAuthenticationContext context)
        {
            throw new NotImplementedException();
        }

        public Task AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            throw new NotImplementedException();
        }

        public Task AuthenticateExternalAsync(ExternalAuthenticationContext context)
        {
            throw new NotImplementedException();
        }

        public Task PostAuthenticateAsync(PostAuthenticationContext context)
        {
            throw new NotImplementedException();
        }

        public Task SignOutAsync(SignOutContext context)
        {
            throw new NotImplementedException();
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            throw new NotImplementedException();
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            throw new NotImplementedException();
        }
    }

    public class IdentityUserService : UserServiceBase
    {
        public override Task AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            var subject = Guid.NewGuid().ToString();
            var username = "tuser";

            context.AuthenticateResult = new AuthenticateResult(subject, username, authenticationMethod: "custom");
            return Task.FromResult(0);
        }

        public override Task AuthenticateExternalAsync(ExternalAuthenticationContext context)
        {
            var subject = Guid.NewGuid().ToString();
            var username = "tuser";

            context.AuthenticateResult = new AuthenticateResult(subject, username);
            return Task.FromResult(0);
        }

        public override Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subject = context.Subject;
            return Task.FromResult(0);
        }
    }
}
