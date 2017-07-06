using System;
using System.Threading.Tasks;
using IdentityProvider.Model.ViewModel;

namespace IdentityProvider.Services
{
    public class IdentityService : IIdentityService
    {
        public IdentityViewModel GetIdentity(Guid identityId)
        {
            return GetIdentityAsync(identityId).Result;
        }

        public Task<IdentityViewModel> GetIdentityAsync(Guid identityId)
        {
            var viewModel = new IdentityViewModel
            {
                IdentityId = identityId,
                Alias = "tuser",
                Email = "tuser@exaple.com",
                FirstName = "Test",
                LastName = "User"
            };

            return Task.FromResult(viewModel);
        }
    }
}