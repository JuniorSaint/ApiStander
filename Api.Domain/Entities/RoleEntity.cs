using System;
using Microsoft.AspNetCore.Identity;

namespace Api.Domain.Entities
{
    public class RoleEntity : IdentityRole<Guid>
    {
        public IEnumerable<UserRoleEntity> UserRoles { get; set; }
    }
}

