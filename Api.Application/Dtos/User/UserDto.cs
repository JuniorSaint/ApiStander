using System;
using Api.Data.Utilities;

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
        public string PhoneNumber { get; set; }
        public DateTime DateBirthday { get; set; }

        private int _age { get; set; }
        public int Age
        {
            get { return _age; }
            set { _age = new CalcAge(DateBirthday).AgeAlready(); }
        }

    }
}

