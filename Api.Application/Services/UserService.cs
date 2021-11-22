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
    public class UserService : IUserService
    {

        private IUserRepository _repository;
        private readonly IMapper _mapper;
        private SignInManager<UserIdentity> _signIn;
        private UserManager<UserIdentity> _userManager;

        public UserService(IUserRepository repository, IMapper mapper, SignInManager<UserIdentity> signIn, UserManager<UserIdentity> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _signIn = signIn;
            _userManager = userManager;
        }

        public Task<UserDto> Post(UserCreateDto usuario)
        {
            var identy = _mapper.Map<UserIdentity>(usuario);
            throw new NotImplementedException();
        }

        public Task<UserUpdateResultDto> Put(UserUpdateDto usuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAllPage(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PatchPassword(UserPasswordUpdateDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<SignInResult> CheckUserPasswordAsync(LoginDto loginDto)
        {
            try
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(user => user.Email.ToLower() == loginDto.Email.ToLower() && user.IsActive == Domain.Enum.IsActive.yes);
                return await _signIn.CheckPasswordSignInAsync(user, loginDto.Password, false);
            }
            catch (ArgumentException)
            {
                throw new Exception("Erro ao tentar verificar a senha");
            }
        }
    }
}
