using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Identity;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IUserRepository : IRepository<UserIdentity>
    {

    }
}

