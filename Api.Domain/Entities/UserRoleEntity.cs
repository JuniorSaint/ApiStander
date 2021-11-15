using System;
using Microsoft.AspNetCore.Identity;

namespace Api.Domain.Entities
{
    public class UserRoleEntity : BaseEntities        // IdentityUserRole<Guid>
    {
        public Guid UserId { get; set; }
        public UserEntity UserEntity { get; set; }
        public Guid RoleId { get; set; }
        public UserEntity RoleEntity { get; set; }
    }
}

