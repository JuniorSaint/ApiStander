using System;
using Api.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Api.Domain.Entities
{
    public class UserEntity : IdentityUser<Guid>
    {
        public string UserImage { get; set; }
        public IsActive IsActive { get; set; }
        public UserType UserType { get; set; }
        public IEnumerable<UserRoleEntity> UserRoles { get; set; }
    }
}

