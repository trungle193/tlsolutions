using System;
using Microsoft.AspNetCore.Identity;

namespace TLSolutions.Entities.Identity
{
    public class AppUserRoles : IdentityUserRole<Guid>
    {
        public AppRole Role { get; set; }
        public AppUser User { get; set; }
    }
}
