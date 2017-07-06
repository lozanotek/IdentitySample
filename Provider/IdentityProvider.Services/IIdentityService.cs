using System;
using System.Threading.Tasks;
using IdentityProvider.Model.ViewModel;

namespace IdentityProvider.Services
{
    public interface IIdentityService
    {
        IdentityViewModel GetIdentity(Guid identityId);
        Task<IdentityViewModel> GetIdentityAsync(Guid identityId);
    }
}
