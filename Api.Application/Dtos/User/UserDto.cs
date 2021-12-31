using System;

namespace Api.Application.Dtos.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public bool IsActive { get; set; }
        public string UserType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UserImage { get; set; }
        public string Title { get; set; }

    }
}

