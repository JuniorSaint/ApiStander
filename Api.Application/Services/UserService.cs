using Microsoft.AspNetCore.Identity;
using Api.Domain.Entities;
using AutoMapper;
using Api.Application.Interfaces;
using Api.Domain.Interfaces;
using Api.Application.Dtos.User;

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

        public Task<UserDto> Post(UserCreateDto usuario)
        {
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
    }
}
