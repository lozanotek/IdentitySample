using System;

namespace IdentityProvider.Model.ViewModel
{
    public class CredentialInputModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class CredentialResult
    {
        public Guid IdentityId { get; set; }
        public Guid CredentialId { get; set; }
    }
}
