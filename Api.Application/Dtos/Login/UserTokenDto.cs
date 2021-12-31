using System;
namespace Api.Application.Dtos.Login
{
    public class UserTokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

