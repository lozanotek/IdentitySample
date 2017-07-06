using System.Threading.Tasks;
using IdentityProvider.Model.ViewModel;

namespace IdentityProvider.Services
{
    public interface ICredentialProvider
    {
        CredentialResult Validate(CredentialInputModel credential);
        Task<CredentialResult> ValidateAsync(CredentialInputModel credential);
    }
}
