using System;

namespace IdentityProvider.Model.Domain
{
    public class Session
    {
        public Guid SessionId { get; set; }
        public Guid IdentityId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
