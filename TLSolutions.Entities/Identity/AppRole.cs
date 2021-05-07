using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
namespace TLSolutions.Entities.Identity
{
    public class AppRole : IdentityRole<Guid>
    {
        public ICollection<AppUserRoles> UserRoles { get; set; }
    }
}
