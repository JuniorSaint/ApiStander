using Api.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Api.Data.Identity
{
    public class UserIdentity : IdentityUser
    {
        public string UserImage { get; set; }
        public IsActive IsActive { get; set; }
        public UserType UserType { get; set; }
    }
}

