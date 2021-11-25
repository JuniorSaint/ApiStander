using System;
using Api.Data.Identity;

namespace Api.Data.Repositories
{
    public class UserRepository : BaseRepository<UserIdentity>, IUserRepository
    {
        public UserRepository()
        {
        }
    }
}

