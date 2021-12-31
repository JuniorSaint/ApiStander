
namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntities
    {
        public string UserImage { get; set; }
        public bool IsActive { get; set; }
        public string UserType { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
     }
}

