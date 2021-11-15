using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> FindByLoginAsync(UserEntity user); // Seleciona email e pass para poder logar 

        Task<UserEntity> GetByEmailAsync(string email); //seleciona um email específico

        Task<bool> UpdatePasswordAsync(UserEntity password); // Altera somente a senha
    }
}

