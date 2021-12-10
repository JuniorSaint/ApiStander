using Microsoft.AspNetCore.Identity;
using Api.Domain.Entities;
using AutoMapper;
using Api.Application.Interfaces;
using Api.Domain.Interfaces;
using Api.Application.Dtos.User;
using Api.Data.Identity;
using Microsoft.EntityFrameworkCore;
using Api.Application.Dtos.Login;

namespace Api.Application.Services
{
    public class UserService
    { 
        //private IUserRepository _repository;
        //private readonly IMapper _mapper;

        //public UserService(IUserRepository repository, IMapper mapper)
        //{
        //    _repository = repository;
        //    _mapper = mapper;

        //}

        //public Task<UserDto> Post(UserCreateDto usuario)
        //{
        //    var entity = _mapper.Map<UserIdentity>(usuario;
        //    var result = await _repository.InsertAsync(entity);
        //    return _mapper.Map<UserDto>(result);
        //}

        //public Task<UserUpdateResultDto> Put(UserUpdateDto usuario)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> Delete(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<UserDto> Get(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<UserDto>> GetAll()
        //{
        //    var listEntity = await _repository.SelectAllAsync();
        //    return _mapper.Map<IEnumerable<UserDto>>(listEntity);
        //}

        //public Task<IEnumerable<UserDto>> GetAllPage(int skip, int take)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> PatchPassword(UserPasswordUpdateDto user)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<SignInResult> CheckUserPasswordAsync(LoginDto loginDto)
        //{
        //    try
        //    {
        //        //var user = await _userManager.Users.SingleOrDefaultAsync(user => user.Email.ToLower() == loginDto.Email.ToLower() && user.IsActive == Domain.Enum.IsActive.yes);
        //        //return await _signIn.CheckPasswordSignInAsync(user, loginDto.Password, false);
        //    }
        //    catch (ArgumentException)
        //    {
        //        throw new Exception("Erro ao tentar verificar a senha");
        //    }
        //}
    }
}
