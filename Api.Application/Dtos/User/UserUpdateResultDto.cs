using System;

namespace Api.Application.Dtos.User
{
    public class UserUpdateResultDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public bool IsActive { get; set; }
        public string UserType { get; set; }
        public string UserImage { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateBirthday { get; set; }
    }
}

