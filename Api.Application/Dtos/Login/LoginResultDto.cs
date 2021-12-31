using System;
namespace Api.Application.Dtos.Login
{
    public class LoginResultDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public bool IsActive { get; set; }
        public string UserType { get; set; }
    }
}

