using Api.Application.Dtos;
using Api.Application.Dtos.Login;
using Api.Application.Dtos.User;
using Api.Domain.Pagination;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Post(UserCreateDto user);
        Task<UserUpdateResultDto> Put(UserUpdateDto user);
        Task<bool> Delete(Guid id);
        Task<UserDto> GetById(Guid id);
        Task<UserDto> GetByEmail(string email);
        Task<bool> PatchPassword(UserPasswordUpdateDto user);
        Task<PageList<UserDto>> GetAllByTerm(PageParams pageParams);
    }
}

