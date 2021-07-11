using System;
using System.Collections.Generic;
using Pic.Shared.Data.Entities;

namespace Pic.Auth.Data.Entities
{
    public class IdentityUser : BaseEntity
    {
        public string UserName { get; set; } = default!;

        public string PasswordHash { get; set; } = default!;

        public string? ProfilePicture { get; set; }

        public string? EmailAddress { get; set; }

        public string? RegistrationToken { get; set; }

        public DateTime? RegistrationTokenExpiryDate { get; set; }

        public bool IsActivated { get; set; }

        public int FailedLoginAttemptsCount { get; set; }

        public DateTime? FailedLoginAttemptsCountExpiryDate { get; set; }

        public IEnumerable<Role> Roles { get; set; } = default!;
    }
}