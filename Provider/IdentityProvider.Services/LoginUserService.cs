using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using IdentityProvider.Model.ViewModel;
using IdentityServer3.Core;
using IdentityServer3.Core.Extensions;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;

namespace IdentityProvider.Services
{
    public class LoginUserService : IUserService
    {
        private readonly ICredentialProvider credentialProvider;
        private readonly IIdentityService identityService;

        public LoginUserService(ICredentialProvider credentialProvider, IIdentityService identityService)
        {
            this.credentialProvider = credentialProvider;
            this.identityService = identityService;
        }

        public async Task AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            var username = context.UserName;
            var password = context.Password;

            context.AuthenticateResult = null;

            var credential = new CredentialInputModel
            {
                Username = username,
                Password = password
            };

            var result = await credentialProvider.ValidateAsync(credential);
            if (!result.IsValid)
            {
                return;
            }

            var identityId = result.IdentityId;
            var identity = await identityService.GetIdentityAsync(identityId);

            if (identity == null)
            {
                context.AuthenticateResult = new AuthenticateResult("Invalid identity");
                return;
            }

            context.AuthenticateResult = new AuthenticateResult(identityId.ToString(), identity.Alias);
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subject = context.Subject.GetSubjectId();
            var identity = await identityService.GetIdentityAsync(new Guid(subject));
            if (identity == null)
            {
                context.IssuedClaims = null;
                return;
            }

            var userClaims = new List<Claim>
            {
                new Claim(Constants.ClaimTypes.Subject, subject),
                new Claim(Constants.ClaimTypes.PreferredUserName, identity.Alias),
                new Claim(Constants.ClaimTypes.Name, $"{identity.FirstName} {identity.LastName}"),
                new Claim(Constants.ClaimTypes.GivenName, identity.FirstName),
                new Claim(Constants.ClaimTypes.FamilyName, identity.LastName),
                new Claim(Constants.ClaimTypes.MiddleName, identity.MiddleName ?? string.Empty),
                new Claim(Constants.ClaimTypes.Email, identity.Email)
            };

            context.IssuedClaims = userClaims;
        }

        public Task PreAuthenticateAsync(PreAuthenticationContext context)
        {
            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.FromResult(0);
        }

        public Task AuthenticateExternalAsync(ExternalAuthenticationContext context)
        {
            return Task.FromResult(0);
        }

        public Task PostAuthenticateAsync(PostAuthenticationContext context)
        {
            return Task.FromResult(0);
        }

        public Task SignOutAsync(SignOutContext context)
        {
            return Task.FromResult(0);
        }
    }
}
