using System;
using System.Threading.Tasks;
using IdentityProvider.Model.ViewModel;

namespace IdentityProvider.Services
{
    public class CredentialProvider : ICredentialProvider
    {
        public CredentialResult Validate(CredentialInputModel credential)
        {
            return ValidateAsync(credential).Result;
        }

        public Task<CredentialResult> ValidateAsync(CredentialInputModel credential)
        {
            var result = new CredentialResult
            {
                CredentialId = Guid.NewGuid(),
                IdentityId = Guid.NewGuid(),
                IsValid = true
            };

            return Task.FromResult(result);
        }
    }
}
