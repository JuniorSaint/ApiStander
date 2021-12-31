using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Pagination;

namespace Api.Domain.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLoginAsync(string email, string password); // Seleciona email e pass para poder logar 

        Task<UserEntity> GetByEmail(string email); //seleciona um email específico

        Task<PageList<UserEntity>> GetEventByTermAsync(PageParams pageParams);
    }
}

