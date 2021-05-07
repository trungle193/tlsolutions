using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TLSolutions.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public ICollection<AppUserRoles> UserRoles { get; set; }
    }
}
