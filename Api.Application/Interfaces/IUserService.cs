using Api.Application.Dtos.User;

namespace Api.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Post(UserCreateDto usuario);
        Task<UserUpdateResultDto> Put(UserUpdateDto usuario);
        Task<bool> Delete(Guid id);
        Task<UserDto> Get(Guid id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<IEnumerable<UserDto>> GetAllPage(int skip, int take);
    }
}

