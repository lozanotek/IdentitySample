﻿using System;

namespace IdentityProvider.Model.Domain
{
    public class Identity
    {
        public Guid IdentityId { get; set; }
        public string Alias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
