using System;

namespace IdentityProvider.Model.Domain
{
    public class Credential
    {
        public Guid CredentialId { get; set; }
        public Guid IdentityId { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public string Value { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}