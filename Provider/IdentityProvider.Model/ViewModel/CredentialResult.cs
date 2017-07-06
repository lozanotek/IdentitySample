using System;

namespace IdentityProvider.Model.ViewModel
{
    public class CredentialResult
    {
        public Guid IdentityId { get; set; }
        public Guid CredentialId { get; set; }
        public bool IsValid { get; set; }
    }
}
