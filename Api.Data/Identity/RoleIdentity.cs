using System;
using Microsoft.AspNetCore.Identity;

namespace Api.Data.Identity
{
    public class RoleIdentity
    {
        IEnumerable<UserRoleIdentity> UserRoles { get; set; }
    }
}

