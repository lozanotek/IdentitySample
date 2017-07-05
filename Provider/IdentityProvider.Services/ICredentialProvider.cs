using IdentityProvider.Model.ViewModel;

namespace IdentityProvider.Services
{
    public interface ICredentialProvider
    {
        CredentialResult Validate(CredentialInputModel credential);
    }
}
