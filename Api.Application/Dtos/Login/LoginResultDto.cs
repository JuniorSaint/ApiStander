using System;
using Api.Domain.Enum;

namespace Api.Application.Dtos.Login
{
    public class LoginResultDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public IsActive IsActive { get; set; }
        public UserType UserType { get; set; }
    }
}

