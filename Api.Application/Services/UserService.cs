using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Api.Application.Interfaces;
using Api.Domain.Interfaces;
using Api.Application.Dtos.User;
using Api.Domain.Entities;
using Api.Application.Dtos.Login;
using Api.Domain.Pagination;

namespace Api.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> Post(UserCreateDto usuario)
        {
            var entity = _mapper.Map<UserEntity>(usuario);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<UserDto>(result);
        }

        public async Task<UserUpdateResultDto> Put(UserUpdateDto usuario)
        {
            var entity = _mapper.Map<UserEntity>(usuario);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<UserUpdateResultDto>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var result =  await _repository.SelectByIdAsync(id);
            return _mapper.Map<UserDto>(result);
        }


        public Task<bool> PatchPassword(UserPasswordUpdateDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<SignInResult> CheckUserPasswordAsync(LoginDto loginDto)
        {
            try
            {
                //var user = await _userManager.Users.SingleOrDefaultAsync(user => user.Email.ToLower() == loginDto.Email.ToLower() && user.IsActive == Domain.Enum.IsActive.yes);
                //return await _signIn.CheckPasswordSignInAsync(user, loginDto.Password, false);
                return null;
            }
            catch (ArgumentException)
            {
                throw new Exception("Erro ao tentar verificar a senha");
            }
        }

        public async Task<PageList<UserDto>> GetAllByTerm(PageParams pageParams)
        {
            var entity = await _repository.GetEventByTermAsync(pageParams);
            var result = _mapper.Map<PageList<UserDto>>(entity);

            // mapped and fix the problem whit automapper with params
            result.CurrentPage = entity.CurrentPage;
            result.TotalPage = entity.TotalPage;
            result.PageSize = entity.PageSize;
            result.TotalCount = entity.TotalCount;

            return result;
        }

    }
}
